////Nama: “Valorant”, Developer: “Riot Games”, Tahun Rilis: “2020”, Genre: “FPS”,
////Rating: “8.5”, Platform: [“PC”], Mode: [“Multiplayer”], IsOnline: “true”, Harga: “0”
//using System.Collections.Generic;

//namespace Modul10_103022430006.Models
//{
//    public class Game
//    {
//        public int Id { get; set; }
//        public string Nama { get; set; }
//        public string Developer { get; set; }
//        public int TahunRilis { get; set; }
//        public string Genre { get; set; }
//        public double Rating { get; set; }
//        public List<string> Platform { get; set; }
//        public List<string> Mode { get; set; }
//        public bool IsOnline { get; set; }
//        public int Harga { get; set; }

//    }
//}

//2.API yang dibuat mempunyai lokasi sebagai berikut ‘/api/Game, URL domain boleh dari 
//port mana saja, misalnya https://localhost:5069/api/Game (port bebas).
//LABORATORIUM PRAKTIKUM INFORMATIKA
//Fakultas Informatika
//Universitas Telkom
//3. Secara default, program yang dibuat memiliki list/array Game berikut:
//a.Nama: “Valorant”, Developer: “Riot Games”, Tahun Rilis: “2020”, Genre: “FPS”,
//Rating: “8.5”, Platform: [“PC”], Mode: [“Multiplayer”], IsOnline: “true”, Harga: “0”
//b.Nama: “GTA V”, Developer: “Rockstar Games”, Tahun Rilis: “2013”, Genre: “Open
//World”, Rating: “9.5”, Platform: [“PC”, “PS4”, “PS5”, “Xbox”], Mode: [“Singleplayer”, 
//“Multiplayer”], IsOnline: “true”, Harga: “300000”
//c.Nama: “The Witcher 3”, Developer: “CD Projekt Red”, Tahun Rilis: “2015”, Genre:
//“RPG”, Rating: “9.7”, Platform: [“PC”, “PS4”, “PS5”, “Xbox”, “Switch”], Mode:
//[“Singleplayer”], IsOnline: “false”, Harga: “250000”
//d.Dst.
//4.Gunakan API sehingga program tersebut dapat menerima HTTP request sebagai berikut:
//a.GET / api / Game: mengembalikan output berupa list/array dari semua objek Game
//yang tersimpan
//b. GET /api/Game/{id}: mengembalikan output berupa objek Game untuk index “id”
//c. POST /api/Game: menambahkan objek Game baru dengan menyertakan data 
//sesuai class
//d. PUT / api / Game: mengubah data objek Game lama dengan data yang baru pada 
//index “id”
//e. DELETE /api/Game/{id}: menghapus objek Game pada index “id”
//5. Impementasi yang dibuat tidak menggunakan database, cukup disimpan sebagai suatu 
//variable, dan gunakan “static” di variable tersebut yang menyimpan list/array dari objekobjek Games
//6. Dalam pembuatan program/aplikasi ini, anda dapat mengasumsikan bahwa input dari 
//user selalu benar dan sesuai dengan tipe data yang diharapkan


using Microsoft.AspNetCore.Mvc;
using Modul10_103022430006.Models;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GameController : ControllerBase
    {
        private static List<Game> games = new List<Game>
        {
            new Game
            {
                Id = 1,
                Nama = "Valorant",
                Developer = "Riot Games",
                TahunRilis = 2020,
                Genre = "FPS",
                Rating = 8.5,
                Platform = new List<string> { "PC" },
                Mode = new List<string> { "Multiplayer" },
                IsOnline = true,
                Harga = 0
            },
            new Game
            {
                Id = 2,
                Nama = "GTA V",
                Developer = "Rockstar Games",
                TahunRilis = 2013,
                Genre = "Open World",
                Rating = 9.5,
                Platform = new List<string> { "PC", "PS4", "PS5", "Xbox" },
                Mode = new List<string> { "Singleplayer", "Multiplayer" },
                IsOnline = true,
                Harga = 300000
            },
            new Game
            {
                Id = 3,
                Nama = "The Witcher 3",
                Developer = "CD Projekt Red",
                TahunRilis = 2015,
                Genre = "RPG",
                Rating = 9.7,
                Platform = new List<string> { "PC", "PS4", "PS5", "Xbox", "Switch" },
                Mode = new List<string> { "Singleplayer" },
                IsOnline = false,
                Harga = 250000
            }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return Ok(games);
        }
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var game = games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }
        [HttpPost]
        public ActionResult Post([FromBody] Game game)
        {
            game.Id = games.Count + 1;
            games.Add(game);
            return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Game updatedGame)
        {
            var gameIndex = games.FindIndex(g => g.Id == id);
            if (gameIndex == -1)
            {
                return NotFound();
            }
            updatedGame.Id = id;
            games[gameIndex] = updatedGame;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var gameIndex = games.FindIndex(g => g.Id == id);
            if (gameIndex == -1)
            {
                return NotFound();
            }
            games.RemoveAt(gameIndex);
            return NoContent();

        }
    }
}

