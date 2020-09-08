using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiStarWar.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;

namespace ApiStarWar.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IRequetMethods requestMethod;

        public FilmeController(IRequetMethods _requestMethod)
        {
            requestMethod = _requestMethod;
        }

        #region
          //Basicamente eu estou utilizando uma thread e com essa thread
          // o async  await do c# trabalha com o estado de  maquina dessa forma
          // eu consigo fazer a  otimização da mesma e  trabalhar com assincronicidade de forma escalavel
        #endregion
        [HttpGet]
        public async Task<IActionResult> ProcessaComAsyncAwait(int id)
        {

            var recuperaFilme   =    requestMethod.GetFilmes(id);
            var recuperaPlaneta =    requestMethod.GetPlaneta(id);
            var recuperaSpecie  =    requestMethod.GetSpecies(id);
            var recuperaVeiculo =    requestMethod.GetVeiculo(id);

            var anonimo = new
            {
                filme = await recuperaFilme,
                planeta = await recuperaPlaneta,
                specie = await recuperaSpecie,
                veiculo = await recuperaVeiculo
            };

            return Ok(anonimo);
        }

        #region
        //Nesse cenario eu mesclo a utilização de taskRun com o async await, como eu coloco
        //todo fluxo dentro de outra tarefa quando o main thread realizar o retorno eu ainda 
        //continuo fazendo o processamento a utilizando do task run é recomendada quando possuimos processamentos
        // do tipo cpu bound ou seja calculos,somas e outros tipos de operações que exigem capacidade do processador
        //nesse caso apenas é um get de uma api mas em outra cenario que exigem processamento essa abordagem seria valida.
        #endregion
        [HttpGet]
        public async Task<IActionResult> ProcessaComTaskRun(int valor)
        {
            object anonimo = null;

             _=Task.Run(async() =>
             {
                var recuperaFilme = await requestMethod.GetFilmes(valor);
                var recuperaPlaneta = await requestMethod.GetPlaneta(valor);
                var recuperaSpecie = await requestMethod.GetSpecies(valor);
                var recuperaVeiculo = await requestMethod.GetVeiculo(valor);

                anonimo = new
                {
                    filme = recuperaFilme,
                    planeta =  recuperaPlaneta,
                    specie = recuperaSpecie,
                    veiculo = recuperaVeiculo
                };

            });

            return Ok("Quando o processamento acabar vc sera notificado");
        }
    }
}