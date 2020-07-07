using System;
using System.Collections.Generic;
using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Microsoft.Extensions.Configuration;
using poc.memory.leak.interfaces;

namespace poc.memory.leak.repository
{
    public class ExampleRepository : IExampleRepository
    {

        private readonly IConfiguration _configuration;
        private IBucket bucket;
        
        public ExampleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IBucket GetBucketInstance()
        {
            if (bucket != null)
            {
                return bucket;
            }
            
            var uri = _configuration.GetValue<string>("Couchbase:Uri");
            var user = _configuration.GetValue<string>("Couchbase:User");
            var pass = _configuration.GetValue<string>("Couchbase:Password");
            var bucketName = _configuration.GetValue<string>("Couchbase:Bucket");
            
            var cluster = new Cluster(new ClientConfiguration
            {
                Servers = new List<Uri> { new Uri(uri) }
            });

            var authenticator = new PasswordAuthenticator(user, pass);
            cluster.Authenticate(authenticator);
            bucket = cluster.OpenBucket(bucketName);
            
            return bucket;

        }

        public object GetItem(string item)
        {

            if (string.IsNullOrEmpty(item))
            {
                return null;
            }

            var myBucket = GetBucketInstance();

            var response = myBucket.GetDocument<object>(item);

            return response.Success ? response.Document.Content : null;
        }
    }
}