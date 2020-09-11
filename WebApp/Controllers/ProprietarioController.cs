using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Threading.Tasks;
using WebApp.ApiServices;
using WebApp.Models.Proprietario;

namespace WebApp.Controllers
{
    public class ProprietarioController : Controller
    {
        private readonly IProprietarioApi _proprietarioApi;

        public ProprietarioController(IProprietarioApi proprietarioApi)
        {
            _proprietarioApi = proprietarioApi;
        }

        // GET: Proprietario
        public async Task<ActionResult> Index()
        {
            var proprietarios = await _proprietarioApi.GetAsync();

            return View(proprietarios);
        }

        // GET: Proprietario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Proprietario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proprietario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CriarProprietarioViewModel criarProprietarioViewModel)
        {
            var urlFoto = UploadFotoProprietario(criarProprietarioViewModel.Foto);

            criarProprietarioViewModel.UrlFoto = urlFoto;

            await _proprietarioApi.PostAsync(criarProprietarioViewModel);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Proprietario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Proprietario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Proprietario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proprietario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private string UploadFotoProprietario(IFormFile foto)
        {
            var reader = foto.OpenReadStream();
            var cloudStorageAccount = CloudStorageAccount.Parse(@"DefaultEndpointsProtocol=https;AccountName=revisaoazure;AccountKey=pIRWbBZIntC3YZ+0PXpNNb9DlHxyYUGA039hFx1TePl0PmoK+OKwaRs20fXdSrKUClsfDRg7onNizE/nTqqnzQ==;EndpointSuffix=core.windows.net");
            var blobClient = cloudStorageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("fotos-proprietarios");
            container.CreateIfNotExists();
            var blob = container.GetBlockBlobReference(Guid.NewGuid().ToString());
            blob.UploadFromStream(reader);
            var destinoDaImagemNaNuvem = blob.Uri.ToString();

            return destinoDaImagemNaNuvem;
        }
    }
}
