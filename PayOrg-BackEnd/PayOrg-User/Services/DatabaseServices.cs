using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayOrgUser.Services;

namespace PayOrgUser;

interface IDatabaseService
{
    public Task<HttpStatusCode> Insert(QueryParameters queryParameters, User payOrgUser);
    public Task<HttpStatusCode> Update(QueryParameters queryParameters, User payOrgUse);
    public Task<HttpStatusCode> Delete(QueryParameters queryParameters, User payOrgUser);
    public Task<HttpStatusCode> Select(QueryParameters queryParameters, User payOrgUser);

}

class DatabaseService : IDatabaseService 
{
    QueueServices _queueServices = new QueueServices();
    
   
    public async Task<HttpStatusCode> Insert(QueryParameters queryParameters, User payOrgUser = null){
        
        string message = JsonConvert.SerializeObject(new {user = payOrgUser, queryParameters = queryParameters});
        //var task = await _queueServices.CreateMessage(message);
        throw new NotImplementedException();
    }
     public async Task<HttpStatusCode> Update(QueryParameters queryParameters, User payOrgUser){
        
        throw new NotImplementedException();
    }
     public async Task<HttpStatusCode> Delete(QueryParameters queryParameters, User payOrgUser){
        
        throw new NotImplementedException();
    }
     public async Task<HttpStatusCode> Select(QueryParameters queryParameters, User payOrgUser){
        
        throw new NotImplementedException();
    }
}
