﻿using System;
using System.Windows.Forms;
using Fusee.Engine;
using Fusee.Math;
using MouseButtons = Fusee.Engine.MouseButtons;


namespace Examples.CubeAndTiles
{
    [FuseeApplication(Name = "Cube & Tiles", Description = "Shows an entire game including user input, object texturing, and sound.")]
    public class CubeAndTiles : RenderCanvas
    {
        #region CubeAndTiles Shader

        // GLSL
        private const string Vs = @"
            attribute vec4 fuColor;
            attribute vec3 fuVertex;
            attribute vec3 fuNormal;
            attribute vec2 fuUV;
        
            varying vec4 vColor;
            varying vec3 vNormal;
            varying vec2 vUV;
        
            uniform mat4 FUSEE_MV;
            uniform mat4 FUSEE_P;
            uniform mat4 FUSEE_ITMV;

            void main()
            {
                mat4 FUSEE_MVP = FUSEE_P * FUSEE_MV;
                gl_Position = FUSEE_MVP * vec4(fuVertex, 1.0);

                vNormal = mat3(FUSEE_ITMV[0].xyz, FUSEE_ITMV[1].xyz, FUSEE_ITMV[2].xyz) * fuNormal;
                vUV = fuUV;
            }";

        private const string Ps = @"
            #ifdef GL_ES
                precision highp float;
            #endif
        
            uniform sampler2D vTexture;
            uniform vec4 vColor;
            varying vec3 vNormal;
            varying vec2 vUV;

            void main()
            {
                vec4 colTex = vColor * texture2D(vTexture, vUV);
                // colh gl_FragColor = dot(vColor, vec4(0, 0, 0, 1)) * colTex * dot(vNormal, vec3(0, 0, 1));
                gl_FragColor = dot(vColor, vec4(0, 0, 0, 1)) * colTex * dot(vNormal, vec3(0, 0, -1));
            }";

        #endregion

        // variables
        private static Level _exampleLevel;
        private static Stereo3D _stereo3D;

        private ShaderProgram _shaderProgram;
        
        private static float _angleHorz = 0.4f;
        private static float _angleVert = 2.4f;
        private static float _angleVelHorz, _angleVelVert;

        private static bool _topView;

        private const float RotationSpeed = 1f;
        private const float Damping = 0.92f;

        // Modifications for trypticon
        private const int _dispHorz = 3;
        private const int _dispVert = 1;

        // Init()
        public override void Init()
        {
            RC.ClearColor = new float4(0f, 0f, 0f, 1);
            
            _shaderProgram = RC.CreateShader(Vs, Ps);
            RC.SetShader(_shaderProgram);

            // Modifications for trypticon
            //VideoWall(1, 1, true, true);
            //SetWindowSize(1280, 800, false, 100, 100);
            _stereo3D = new Stereo3D(RC, Stereo3DMode.Oculus, 1280, 800);
            _exampleLevel = new Level(RC, _shaderProgram, _stereo3D);
        }

        // RenderAFrame()
        public override void RenderAFrame()
        {
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            // keyboard
            if (Input.Instance.IsKeyDown(KeyCodes.V))
            {
                _angleVelHorz = 0.0f;
                _angleVelVert = 0.0f;

                if (_topView)
                {
                    _angleHorz = 0.4f;
                    _angleVert = -1.0f;

                    _topView = false;
                }
                else
                {
                    _angleHorz = 0.0f;
                    _angleVert = 0.0f;
                    _topView = true;
                }
            }

            // Pull user input.
            if (Input.Instance.IsKey(KeyCodes.D1))
            {
                _stereo3D.ChangeStereoMode(Stereo3DMode.Anaglyph, Width, Height);
                Resize();
            }

            if (Input.Instance.IsKey(KeyCodes.D2))
            {
                _stereo3D.ChangeStereoMode(Stereo3DMode.Oculus, Width, Height);
                Resize();
            }

            if (Input.Instance.IsKey(KeyCodes.D3))
            {
                _stereo3D.ChangeStereoMode(Stereo3DMode.OverUnder, Width, Height);
                Resize();
            }

            if (Input.Instance.IsKey(KeyCodes.D4))
            {
                _stereo3D.ChangeStereoMode(Stereo3DMode.LeftRight, Width, Height);
                Resize();
            }
                

            if (Input.Instance.IsKey(KeyCodes.Escape))
                CloseGameWindow(); // Call to opentk to close the application.

            if (Input.Instance.IsKeyDown(KeyCodes.S))
                Audio.Instance.SetVolume(Audio.Instance.GetVolume() > 0 ? 0 : 100);

            if (Input.Instance.IsKeyDown(KeyCodes.C))
            {
                _exampleLevel.UseStereo3D = !_exampleLevel.UseStereo3D; 
                Resize();
            }

            if (Input.Instance.IsKey(KeyCodes.Left))
                _exampleLevel.MoveCube(Level.Directions.Left);

            if (Input.Instance.IsKey(KeyCodes.Right))
                _exampleLevel.MoveCube(Level.Directions.Right);

            if (Input.Instance.IsKey(KeyCodes.Up))
                _exampleLevel.MoveCube(Level.Directions.Forward);

            if (Input.Instance.IsKey(KeyCodes.Down))
                _exampleLevel.MoveCube(Level.Directions.Backward);

            // mouse
            if (Input.Instance.GetAxis(InputAxis.MouseWheel) > 0)
                _exampleLevel.ZoomCamera(50);

            if (Input.Instance.GetAxis(InputAxis.MouseWheel) < 0)
                _exampleLevel.ZoomCamera(-50);

            if (Input.Instance.IsButton(MouseButtons.Left))
            {
                _angleVelHorz = RotationSpeed*Input.Instance.GetAxis(InputAxis.MouseX);
                _angleVelVert = RotationSpeed*Input.Instance.GetAxis(InputAxis.MouseY);
            }
            else
            {
                var curDamp = (float) Math.Exp(-Damping*Time.Instance.DeltaTime);

                _angleVelHorz *= curDamp;
                _angleVelVert *= curDamp;
            }

            _angleHorz += _angleVelHorz;
            _angleVert += _angleVelVert;

            // colh var mtxRot = float4x4.CreateRotationZ(_angleHorz)*float4x4.CreateRotationX(_angleVert);
            var mtxRot = float4x4.CreateRotationX(-_angleVert) * float4x4.CreateRotationZ(-_angleHorz);

            _exampleLevel.Render(mtxRot);

            if (_exampleLevel.UseStereo3D)
                _stereo3D.Display();

            Present();
        }

        public override void Resize()
        {
            var aspectRatio = _exampleLevel.UseStereo3D ? _stereo3D.CalculateAspectRatio() : (Width / (float)Height);

            RC.Viewport(0, 0, Width, Height);
            RC.Projection = float4x4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 20, 10000);

            // Set Width and Height and do resize.
            _stereo3D.ScreenWidth = Width;
            _stereo3D.ScreenHeight = Height;
        }

        public static void Main()
        {
            var app = new CubeAndTiles();
            app.Run();
        }
    }
}