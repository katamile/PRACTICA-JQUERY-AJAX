using Newtonsoft.Json;
using PRACTICA_JQUERY_AJAX.Models.Categorias;
using PRACTICA_JQUERY_AJAX.Models.Productos;
using System.Text;
using System;

namespace PRACTICA_JQUERY_AJAX.Services.Productos
{
    public class ProductService : IProductService
    {
        private readonly string APIBaseURL;
        private readonly HttpClient _httpClient;


        public ProductService(HttpClient httpClient)
        {
            APIBaseURL = Environment.GetEnvironmentVariable("APIBaseURL");
            _httpClient = httpClient;
        }

        public async Task<List<Products>> ObtenerProductos()
        {
            string url = $"{APIBaseURL}/products";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            string content = await response.Content.ReadAsStringAsync();
            List<Products> products = JsonConvert.DeserializeObject<List<Products>>(content);

            return products;
        }

        public async Task<Products> ObtenerProductoId(int id)
        {
            string url = $"{APIBaseURL}/products/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            string content = await response.Content.ReadAsStringAsync();
            Products product = JsonConvert.DeserializeObject<Products>(content);

            return product;
        }

        public async Task<Products> CrearProducto(Products product)
        {
            string url = $"{APIBaseURL}/Products";

            string json = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return null;

            string createdContent = await response.Content.ReadAsStringAsync();

            Products createdProduct = JsonConvert.DeserializeObject<Products>(createdContent);

            return createdProduct;
        }


        public async Task<Products> ActualizarProducto(int id, Products products)
        {
            Products productoToUpdate = await ObtenerProductoId(id);

            if (productoToUpdate == null)
                return null;

            if (!string.IsNullOrWhiteSpace(products.Titulo) && productoToUpdate.Titulo != products.Titulo)
                productoToUpdate.Titulo = products.Titulo;

            if (!string.IsNullOrWhiteSpace(products.Descripcion) && productoToUpdate.Descripcion != products.Descripcion)
                productoToUpdate.Descripcion = products.Descripcion;

            if (products.Precio > 0 && productoToUpdate.Precio != products.Precio)
                productoToUpdate.Precio = products.Precio;

            //if (productoToUpdate.Category.Id != products.Category.Id)
            //    productoToUpdate.Category.Id = products.Category.Id;

            string url = $"{APIBaseURL}/Products/{id}";

            string json = JsonConvert.SerializeObject(productoToUpdate);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return null;

            string updatedContent = await response.Content.ReadAsStringAsync();

            Products updatedProduct = JsonConvert.DeserializeObject<Products>(updatedContent);

            return updatedProduct;
        }

    }
}
