using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Teste.Domain.Entidades;

[TestClass]
public class AdministradorServicoTeste
{
    private DbContexto CriarContextodeTeste()
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        var builder = new ConfigurationBuilder()
        .SetBasePath(path ?? Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();
    }

    [TestMethod]
    public void TestandoBuscaPorId()
    {
        var context = CriarContextodeTeste;
        contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");


        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        administradorServico.Incluir(adm);
        var adms = administradorServico.BuscaPorId(adm.Id);
        

        Assert.AreEqual(1, adm.Id);
    }
}