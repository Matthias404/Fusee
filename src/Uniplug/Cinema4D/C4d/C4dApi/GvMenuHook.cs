//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace C4d {

public class GvMenuHook : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GvMenuHook(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(GvMenuHook obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~GvMenuHook() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_GvMenuHook(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public GvMenuHook() : this(C4dApiPINVOKE.new_GvMenuHook(), true) {
  }

  public GvNodeMaster master {
    set {
      C4dApiPINVOKE.GvMenuHook_master_set(swigCPtr, GvNodeMaster.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvMenuHook_master_get(swigCPtr);
      GvNodeMaster ret = (cPtr == global::System.IntPtr.Zero) ? null : new GvNodeMaster(cPtr, false);
      return ret;
    } 
  }

  public BaseDocument document {
    set {
      C4dApiPINVOKE.GvMenuHook_document_set(swigCPtr, BaseDocument.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvMenuHook_document_get(swigCPtr);
      BaseDocument ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseDocument(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_void user {
    set {
      C4dApiPINVOKE.GvMenuHook_user_set(swigCPtr, SWIGTYPE_p_void.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvMenuHook_user_get(swigCPtr);
      SWIGTYPE_p_void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
      return ret;
    } 
  }

  public int menu_id {
    set {
      C4dApiPINVOKE.GvMenuHook_menu_id_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.GvMenuHook_menu_id_get(swigCPtr);
      return ret;
    } 
  }

  public BaseContainer menu {
    set {
      C4dApiPINVOKE.GvMenuHook_menu_set(swigCPtr, BaseContainer.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = C4dApiPINVOKE.GvMenuHook_menu_get(swigCPtr);
      BaseContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new BaseContainer(cPtr, false);
      return ret;
    } 
  }

}

}
