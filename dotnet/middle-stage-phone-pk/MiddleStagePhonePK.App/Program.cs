﻿using IdentityModel.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAccessTokenManagement( options =>
    {

        string backendAuthAddress = builder.Configuration.GetValue<string>("backendAuthURL")
                                    ?? throw new ApplicationException("backendAuthURL cannot be null");
        string backendAuthClientID = builder.Configuration.GetValue<string>("backendAuthClientID")
                                    ?? throw new ApplicationException("backendAuthClientID cannot be null");
        string backendAuthClientSecret = builder.Configuration.GetValue<string>("backendAuthClientSecret")
                                    ?? throw new ApplicationException("backendAuthClientSecret cannot be null");
        string backendAuthClientScope = builder.Configuration.GetValue<string>("backendAuthClientScope")
                                    ?? throw new ApplicationException("backendAuthClientScope cannot be null");

        string serverName = (new Uri(backendAuthAddress)).Host;

        options.Client.Clients.Add(serverName, new ClientCredentialsTokenRequest 
        {
            Address = backendAuthAddress,
            ClientId = backendAuthClientID,
            ClientSecret = backendAuthClientSecret,
            Scope = backendAuthClientScope
        });
    }
);

builder.Services.AddClientAccessTokenHttpClient("client", configureClient: client =>
{
    string backendBaseURL = builder.Configuration.GetValue<string>("backendBaseURL")
                                ?? throw new ApplicationException("backendBaseURL cannot be null");

    client.BaseAddress = new Uri(backendBaseURL);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
