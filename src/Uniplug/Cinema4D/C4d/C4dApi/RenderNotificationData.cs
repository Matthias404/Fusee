/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 0.0.1
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace C4d {

using System;
using System.Runtime.InteropServices;

public class RenderNotificationData : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal RenderNotificationData(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(RenderNotificationData obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~RenderNotificationData() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_RenderNotificationData(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public RenderNotificationData() : this(C4dApiPINVOKE.new_RenderNotificationData(), true) {
  }

  public BaseDocument doc {
    set {
      C4dApiPINVOKE.RenderNotificationData_doc_set(swigCPtr, BaseDocument.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.RenderNotificationData_doc_get(swigCPtr);
      BaseDocument ret = (cPtr == IntPtr.Zero) ? null : new BaseDocument(cPtr, false);
      return ret;
    } 
  }

  public bool start {
    set {
      C4dApiPINVOKE.RenderNotificationData_start_set(swigCPtr, value);
    } 
    get {
      bool ret = C4dApiPINVOKE.RenderNotificationData_start_get(swigCPtr);
      return ret;
    } 
  }

  public bool animated {
    set {
      C4dApiPINVOKE.RenderNotificationData_animated_set(swigCPtr, value);
    } 
    get {
      bool ret = C4dApiPINVOKE.RenderNotificationData_animated_get(swigCPtr);
      return ret;
    } 
  }

  public bool external {
    set {
      C4dApiPINVOKE.RenderNotificationData_external_set(swigCPtr, value);
    } 
    get {
      bool ret = C4dApiPINVOKE.RenderNotificationData_external_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_Render render {
    set {
      C4dApiPINVOKE.RenderNotificationData_render_set(swigCPtr, SWIGTYPE_p_Render.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.RenderNotificationData_render_get(swigCPtr);
      SWIGTYPE_p_Render ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_Render(cPtr, false);
      return ret;
    } 
  }

}

}