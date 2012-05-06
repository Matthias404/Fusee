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

public class C4DAtom : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal C4DAtom(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(C4DAtom obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public int GetType() {
    int ret = C4dApiPINVOKE.C4DAtom_GetType(swigCPtr);
    return ret;
  }

  public int GetRealType() {
    int ret = C4dApiPINVOKE.C4DAtom_GetRealType(swigCPtr);
    return ret;
  }

  public int GetDiskType() {
    int ret = C4dApiPINVOKE.C4DAtom_GetDiskType(swigCPtr);
    return ret;
  }

  public bool IsInstanceOf(int id) {
    bool ret = C4dApiPINVOKE.C4DAtom_IsInstanceOf(swigCPtr, id);
    return ret;
  }

  public int GetClassification() {
    int ret = C4dApiPINVOKE.C4DAtom_GetClassification(swigCPtr);
    return ret;
  }

  public bool Message(int type, SWIGTYPE_p_void data) {
    bool ret = C4dApiPINVOKE.C4DAtom_Message__SWIG_0(swigCPtr, type, SWIGTYPE_p_void.getCPtr(data));
    return ret;
  }

  public bool Message(int type) {
    bool ret = C4dApiPINVOKE.C4DAtom_Message__SWIG_1(swigCPtr, type);
    return ret;
  }

  public bool MultiMessage(MULTIMSG_ROUTE flags, int type, SWIGTYPE_p_void data) {
    bool ret = C4dApiPINVOKE.C4DAtom_MultiMessage(swigCPtr, (int)flags, type, SWIGTYPE_p_void.getCPtr(data));
    return ret;
  }

  public C4DAtom GetClone(COPYFLAGS flags, AliasTrans trn) {
    IntPtr cPtr = C4dApiPINVOKE.C4DAtom_GetClone(swigCPtr, (int)flags, AliasTrans.getCPtr(trn));
    C4DAtom ret = (cPtr == IntPtr.Zero) ? null : new C4DAtom(cPtr, false);
    return ret;
  }

  public bool CopyTo(C4DAtom dst, COPYFLAGS flags, AliasTrans trn) {
    bool ret = C4dApiPINVOKE.C4DAtom_CopyTo(swigCPtr, C4DAtom.getCPtr(dst), (int)flags, AliasTrans.getCPtr(trn));
    return ret;
  }

  public bool Read(SWIGTYPE_p_HyperFile hf, int id, int level) {
    bool ret = C4dApiPINVOKE.C4DAtom_Read(swigCPtr, SWIGTYPE_p_HyperFile.getCPtr(hf), id, level);
    return ret;
  }

  public bool Write(SWIGTYPE_p_HyperFile hf) {
    bool ret = C4dApiPINVOKE.C4DAtom_Write(swigCPtr, SWIGTYPE_p_HyperFile.getCPtr(hf));
    return ret;
  }

  public bool ReadObject(SWIGTYPE_p_HyperFile hf, bool readheader) {
    bool ret = C4dApiPINVOKE.C4DAtom_ReadObject(swigCPtr, SWIGTYPE_p_HyperFile.getCPtr(hf), readheader);
    return ret;
  }

  public bool WriteObject(SWIGTYPE_p_HyperFile hf) {
    bool ret = C4dApiPINVOKE.C4DAtom_WriteObject(swigCPtr, SWIGTYPE_p_HyperFile.getCPtr(hf));
    return ret;
  }

  public bool GetDescription(Description description, DESCFLAGS_DESC flags) {
    bool ret = C4dApiPINVOKE.C4DAtom_GetDescription(swigCPtr, Description.getCPtr(description), (int)flags);
    return ret;
  }

  public bool GetParameter(DescID id, GeData t_data, DESCFLAGS_GET flags) {
    bool ret = C4dApiPINVOKE.C4DAtom_GetParameter(swigCPtr, DescID.getCPtr(id), GeData.getCPtr(t_data), (int)flags);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool SetParameter(DescID id, GeData t_data, DESCFLAGS_SET flags) {
    bool ret = C4dApiPINVOKE.C4DAtom_SetParameter(swigCPtr, DescID.getCPtr(id), GeData.getCPtr(t_data), (int)flags);
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public DynamicDescription GetDynamicDescription() {
    IntPtr cPtr = C4dApiPINVOKE.C4DAtom_GetDynamicDescription(swigCPtr);
    DynamicDescription ret = (cPtr == IntPtr.Zero) ? null : new DynamicDescription(cPtr, false);
    return ret;
  }

  public bool GetEnabling(DescID id, GeData t_data, DESCFLAGS_ENABLE flags, BaseContainer itemdesc) {
    bool ret = C4dApiPINVOKE.C4DAtom_GetEnabling(swigCPtr, DescID.getCPtr(id), GeData.getCPtr(t_data), (int)flags, BaseContainer.getCPtr(itemdesc));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool TranslateDescID(DescID id, DescID res_id, SWIGTYPE_p_p_C4DAtom res_at) {
    bool ret = C4dApiPINVOKE.C4DAtom_TranslateDescID(swigCPtr, DescID.getCPtr(id), DescID.getCPtr(res_id), SWIGTYPE_p_p_C4DAtom.getCPtr(res_at));
    if (C4dApiPINVOKE.SWIGPendingException.Pending) throw C4dApiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public SWIGTYPE_p_ULONG GetDirty(DIRTYFLAGS flags) {
    SWIGTYPE_p_ULONG ret = new SWIGTYPE_p_ULONG(C4dApiPINVOKE.C4DAtom_GetDirty(swigCPtr, (int)flags), true);
    return ret;
  }

  public void SetDirty(DIRTYFLAGS flags) {
    C4dApiPINVOKE.C4DAtom_SetDirty(swigCPtr, (int)flags);
  }

  public SWIGTYPE_p_ULONG GetHDirty(HDIRTYFLAGS mask) {
    SWIGTYPE_p_ULONG ret = new SWIGTYPE_p_ULONG(C4dApiPINVOKE.C4DAtom_GetHDirty(swigCPtr, (int)mask), true);
    return ret;
  }

  public void SetHDirty(HDIRTYFLAGS mask) {
    C4dApiPINVOKE.C4DAtom_SetHDirty(swigCPtr, (int)mask);
  }

}

}