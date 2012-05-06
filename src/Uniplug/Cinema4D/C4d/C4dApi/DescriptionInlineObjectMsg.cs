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

public class DescriptionInlineObjectMsg : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal DescriptionInlineObjectMsg(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(DescriptionInlineObjectMsg obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~DescriptionInlineObjectMsg() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_DescriptionInlineObjectMsg(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public DescriptionInlineObjectMsg() : this(C4dApiPINVOKE.new_DescriptionInlineObjectMsg(), true) {
  }

  public DescID id {
    set {
      C4dApiPINVOKE.DescriptionInlineObjectMsg_id_set(swigCPtr, DescID.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.DescriptionInlineObjectMsg_id_get(swigCPtr);
      DescID ret = (cPtr == IntPtr.Zero) ? null : new DescID(cPtr, false);
      return ret;
    } 
  }

  public AtomArray objects {
    set {
      C4dApiPINVOKE.DescriptionInlineObjectMsg_objects_set(swigCPtr, AtomArray.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.DescriptionInlineObjectMsg_objects_get(swigCPtr);
      AtomArray ret = (cPtr == IntPtr.Zero) ? null : new AtomArray(cPtr, false);
      return ret;
    } 
  }

}

}