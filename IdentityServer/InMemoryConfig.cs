using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;
using Secret = IdentityServer4.Models.Secret;

public static class InMemoryConfig
{
    public static IEnumerable<IdentityResource> GetIdentityResources() =>
      new List<IdentityResource>
      {
          new IdentityResources.OpenId(),
          new IdentityResources.Profile()
      };

    public static List<TestUser> GetUsers() =>
  new List<TestUser>
  {
      new TestUser
      {
          SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
          Username = "Eltaher",
          Password = "1234",
          Claims = new List<Claim>
          {
               new Claim("firstName", "Mohamed"),
              new Claim("LastName", "Eltaher"),
              new Claim("Type", "Customer")
          }
      },
      new TestUser
      {
          SubjectId = "c95ddb8c-79ec-488a-a485-fe57a1462340",
          Username = "Alsir",
          Password = "1234",
          Claims = new List<Claim>
          {
              new Claim("firstName", "Mohamed"),
              new Claim("LastName", "Alsir"),
              new Claim("Type", "Inspector")
          }
      }
  };
    public static IEnumerable<Client> GetClients() =>
    new List<Client>
    {
       new Client
       {
            ClientId = "Customer",
            ClientSecrets = new [] { new Secret("customersecret".Sha512()) },
            AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
            AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId }
        },
         new Client
       {
            ClientId = "Inspector",
            ClientSecrets = new [] { new Secret("inspectorsecret".Sha512()) },
            AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
            AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId }
        }
    };
}