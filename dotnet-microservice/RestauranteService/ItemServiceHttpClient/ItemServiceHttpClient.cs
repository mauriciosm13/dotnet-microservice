﻿using RestauranteService.Dtos;
using System.Text;
using System.Text.Json;

namespace RestauranteService.ItemServiceHttpClient
{
    public class ItemServiceHttpClient : IItemServiceHttpClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public ItemServiceHttpClient(HttpClient client)
        {
            _client = client;
        }
        public async void EnviaRestauranteParaItemService(RestauranteReadDto readDto)
        {
            var contentHttp = new StringContent
                (
                    JsonSerializer.Serialize(readDto),
                    Encoding.UTF8,
                    "application/json"
                );

            await _client.PostAsync(_configuration["ItemService"], contentHttp);
        }
    }
}
