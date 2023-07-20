#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Void MiniIT.Utils.AdvertisingIdFetcher::RequestAdvertisingId(System.Action`1<System.String>,System.Int32)
extern void AdvertisingIdFetcher_RequestAdvertisingId_m63F5A0FD3CCD491E771E16E4A617DB3C62FA77B6 (void);
// 0x00000002 System.Void MiniIT.Utils.AdvertisingIdFetcher::DoRequestAdvertisingId(System.Action`1<System.String>,System.Int32)
extern void AdvertisingIdFetcher_DoRequestAdvertisingId_m81E338661BFC9FC0552A88950419E8C6AE75FEAD (void);
// 0x00000003 System.Void MiniIT.Utils.AdvertisingIdFetcher::WaitForResponse(System.Int32,System.Threading.CancellationToken)
extern void AdvertisingIdFetcher_WaitForResponse_mBA992D5D36CE2531C769874B63BD1FFB52986C5A (void);
// 0x00000004 System.Void MiniIT.Utils.AdvertisingIdFetcher::OnAdvertisingIdReceived(System.String)
extern void AdvertisingIdFetcher_OnAdvertisingIdReceived_m4B9580E8F6D1655D6FA36EFFE47168E40B5F33E0 (void);
// 0x00000005 System.Void MiniIT.Utils.AdvertisingIdFetcher::OnAdvertisingIdReceived(System.String,System.Boolean,System.String)
extern void AdvertisingIdFetcher_OnAdvertisingIdReceived_mD74BF9B79D442B0766BF2C09465A19C04106A3B3 (void);
// 0x00000006 System.Void MiniIT.Utils.AdvertisingIdFetcher::.ctor()
extern void AdvertisingIdFetcher__ctor_m3F4B297146150A6C8C4623680F30DE771F6396FE (void);
// 0x00000007 System.Void MiniIT.Utils.AdvertisingIdFetcher/<WaitForResponse>d__4::MoveNext()
extern void U3CWaitForResponseU3Ed__4_MoveNext_m9B0F369F71BD92FFE5723CD7C7033701F99CA263 (void);
// 0x00000008 System.Void MiniIT.Utils.AdvertisingIdFetcher/<WaitForResponse>d__4::SetStateMachine(System.Runtime.CompilerServices.IAsyncStateMachine)
extern void U3CWaitForResponseU3Ed__4_SetStateMachine_m63E029383376077F1010E663162319F852327129 (void);
// 0x00000009 System.Void MiniIT.Utils.AdvertisingIdPluginCallback::.ctor(System.Action`1<System.String>)
extern void AdvertisingIdPluginCallback__ctor_mE647BC7B02C3FC13ED7250756993B9DB960B67D6 (void);
// 0x0000000A System.Void MiniIT.Utils.AdvertisingIdPluginCallback::onResult(System.String)
extern void AdvertisingIdPluginCallback_onResult_m5C015429F17FCC85271F692FF2F2C2ED4A6D4E51 (void);
static Il2CppMethodPointer s_methodPointers[10] = 
{
	AdvertisingIdFetcher_RequestAdvertisingId_m63F5A0FD3CCD491E771E16E4A617DB3C62FA77B6,
	AdvertisingIdFetcher_DoRequestAdvertisingId_m81E338661BFC9FC0552A88950419E8C6AE75FEAD,
	AdvertisingIdFetcher_WaitForResponse_mBA992D5D36CE2531C769874B63BD1FFB52986C5A,
	AdvertisingIdFetcher_OnAdvertisingIdReceived_m4B9580E8F6D1655D6FA36EFFE47168E40B5F33E0,
	AdvertisingIdFetcher_OnAdvertisingIdReceived_mD74BF9B79D442B0766BF2C09465A19C04106A3B3,
	AdvertisingIdFetcher__ctor_m3F4B297146150A6C8C4623680F30DE771F6396FE,
	U3CWaitForResponseU3Ed__4_MoveNext_m9B0F369F71BD92FFE5723CD7C7033701F99CA263,
	U3CWaitForResponseU3Ed__4_SetStateMachine_m63E029383376077F1010E663162319F852327129,
	AdvertisingIdPluginCallback__ctor_mE647BC7B02C3FC13ED7250756993B9DB960B67D6,
	AdvertisingIdPluginCallback_onResult_m5C015429F17FCC85271F692FF2F2C2ED4A6D4E51,
};
extern void U3CWaitForResponseU3Ed__4_MoveNext_m9B0F369F71BD92FFE5723CD7C7033701F99CA263_AdjustorThunk (void);
extern void U3CWaitForResponseU3Ed__4_SetStateMachine_m63E029383376077F1010E663162319F852327129_AdjustorThunk (void);
static Il2CppTokenAdjustorThunkPair s_adjustorThunks[2] = 
{
	{ 0x06000007, U3CWaitForResponseU3Ed__4_MoveNext_m9B0F369F71BD92FFE5723CD7C7033701F99CA263_AdjustorThunk },
	{ 0x06000008, U3CWaitForResponseU3Ed__4_SetStateMachine_m63E029383376077F1010E663162319F852327129_AdjustorThunk },
};
static const int32_t s_InvokerIndices[10] = 
{
	6750,
	2264,
	2039,
	3948,
	1266,
	4848,
	4848,
	3948,
	3948,
	3948,
};
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_MiniIT_AdvertisingIdFetcher_CodeGenModule;
const Il2CppCodeGenModule g_MiniIT_AdvertisingIdFetcher_CodeGenModule = 
{
	"MiniIT.AdvertisingIdFetcher.dll",
	10,
	s_methodPointers,
	2,
	s_adjustorThunks,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
