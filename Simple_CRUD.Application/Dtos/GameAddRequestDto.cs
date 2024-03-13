using Simple_CRUD.Domain.Entities.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_CRUD.Application.Dtos
{
    public class GameAddRequestDto
    {
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Description { get; set; }
        public DateTime RelizeDate { get; set; }
        public double Price { get; set; }
        public List<GenreAddRequestDto> Genres { get; set; } = new();
        public double Rating { get; set; }
    }

    public class GenreAddRequestDto
    {
        public string Name { get; set; }
    }
}
