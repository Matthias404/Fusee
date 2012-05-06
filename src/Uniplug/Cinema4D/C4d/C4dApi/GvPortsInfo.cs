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

public class GvPortsInfo : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GvPortsInfo(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GvPortsInfo obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GvPortsInfo() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          C4dApiPINVOKE.delete_GvPortsInfo(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public GvPortsInfo() : this(C4dApiPINVOKE.new_GvPortsInfo(), true) {
  }

  public SWIGTYPE_p_p_GvPort in_ports {
    set {
      C4dApiPINVOKE.GvPortsInfo_in_ports_set(swigCPtr, SWIGTYPE_p_p_GvPort.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.GvPortsInfo_in_ports_get(swigCPtr);
      SWIGTYPE_p_p_GvPort ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_p_GvPort(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_p_GvPort out_ports {
    set {
      C4dApiPINVOKE.GvPortsInfo_out_ports_set(swigCPtr, SWIGTYPE_p_p_GvPort.getCPtr(value));
    } 
    get {
      IntPtr cPtr = C4dApiPINVOKE.GvPortsInfo_out_ports_get(swigCPtr);
      SWIGTYPE_p_p_GvPort ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_p_GvPort(cPtr, false);
      return ret;
    } 
  }

  public int nr_of_in_ports {
    set {
      C4dApiPINVOKE.GvPortsInfo_nr_of_in_ports_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.GvPortsInfo_nr_of_in_ports_get(swigCPtr);
      return ret;
    } 
  }

  public int nr_of_out_ports {
    set {
      C4dApiPINVOKE.GvPortsInfo_nr_of_out_ports_set(swigCPtr, value);
    } 
    get {
      int ret = C4dApiPINVOKE.GvPortsInfo_nr_of_out_ports_get(swigCPtr);
      return ret;
    } 
  }

}

}