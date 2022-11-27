// See https://aka.ms/new-console-template for more information
using Autofac;
using MiniBankingApp.Core.BusinessLogic;
using MiniBankingApp.Core.Data;
using MiniBankingApp.Core.Models;
using MiniBankingApp.UI;

var builder = new ContainerBuilder();

builder.RegisterType<UserRepository>().As<IUserRepository>();
builder.RegisterType<AccountRepository>().As<IAccountRepository>();
builder.RegisterType<UserService>().As<IUserService>();
builder.RegisterType<AccountService>().As<IAccountService>();
builder.RegisterType<App>().As<IApp>();

var container = builder.Build();

using var scope = container.BeginLifetimeScope();

var app = scope.Resolve<IApp>();
app.Start();
