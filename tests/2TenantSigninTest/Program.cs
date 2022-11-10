


using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Authorization;
using Azure.ResourceManager.Resources;


// var cred = new DefaultAzureCredential();
// cred.GetToken()

string tokenTenant1 = "";
; 
var datetime1 = DateTime.Parse("2022-11-10 16:52:47.000000");
var tokencredWOG = new ExistingTokenCredential(tokenTenant1, datetime1);

var wogArm = new ArmClient(tokencredWOG);


string tokenTenant2= ""; 
var datetime2 = DateTime.Parse("2022-11-10 17:15:01.000000");
var tokencredTP = new ExistingTokenCredential(tokenTenant2, datetime2);

var tpArm = new ArmClient(tokencredTP);




SubscriptionCollection wogSubs = wogArm.GetSubscriptions();
foreach(var s in wogSubs)
{
   SubscriptionResource sub =  s.Get();
   Console.WriteLine($"SubID: {sub.Id}, Name: {sub.Data.DisplayName}");

   RoleAssignmentCollection raAssignments = sub.GetRoleAssignments();

  
   foreach(var ra in raAssignments)
    {
        
    }

   ResourceGroupResource rgr = sub.GetResourceGroup("gcc-hk");
    
}


SubscriptionCollection tpSubs = tpArm.GetSubscriptions();
foreach(var s in tpSubs)
{
   var sub =  s.Get();
   Console.WriteLine($"SubID: {sub.Value.Id}, Name: {sub.Value.Data.DisplayName}");
}