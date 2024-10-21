namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

[ApiController]
[Route("api/[Controller]")]
public class ToDoItemsController : ControllerBase
{
    private static readonly List<ToDoItem> Items = []; //je to private, nazev by mel zacinat malym pismenkem
    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request)
    {
        try
        {
            var item = request.ToDomain();
            item.ToDoItemId = Items.Count == 0 ? 1 : Items.Max(o => o.ToDoItemId) + 1;
            Items.Add(item);

        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
        return Created();
    }

    [HttpGet]
    public IActionResult Read()
    {
        try
        {
            /*chteli bychom aby to vracelo ToDoItemGetResposeDto, jak to udelat?
            v zadani je chyba v tip - nepouzijeme Add ale Select
            co dela Select?
            Je to medota iterovatelnych objektu (to je i List), kdy na zaklade puvodniho iterovatelneho objektu vygenerujeme novy iterovatelny objekt

            var novyObjekt = puvodniObjekt.Select(transformacni funkce)

            priklad
            var cisla = new List<int>() { 1, 2, 3 };
            var novaCisla = cisla.Select(o => -1 * o); BACHA: novaCisla budou IEnumerable

            co to udela? Cezme to kazde cislo z List cisla, vynasobi to -1 a da do noveho IEnumerable novaCisla
            vysledkem je IEnumerable novaCisla co ma v sobe {-1,-2,-3}
            */

            //dopln :)
            //var itemsToSent = Items.Select();

            //plus dodelat funcionalitu kdyz Items is null - pokud jsi fajnsmekr tak to muzes skusit udelat na jeden radek :)

            return Ok(Items);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{toDoItemId:int}")]
    public IActionResult ReadById(int toDoItemId)
    {
        try
        {
            var item = Items.FirstOrDefault(i => i.ToDoItemId == toDoItemId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item); //opet, chceme to poslat ve formatu ToDoItemsGetResponseDto
            /*
            opet pokud se toho nebojis, musez skusit udelat to kod
             if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
            byl na jeden radek :)
            TIP ternarni operator ?:
            */
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        //nebudu protestovat proti tomuto zpusobu :) funguje to a je to jeden ze zpusobu
        //slo by to taky pres FindIndex nebo Find
        var existingProduct = Items.FirstOrDefault(item => item.ToDoItemId == toDoItemId);
        if (existingProduct == null)
        {
            return NotFound();
        }

        try
        {
            existingProduct.Name = request.Name;
            existingProduct.Description = request.Description;
            existingProduct.IsCompleted = request.IsCompleted;
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }

        return NoContent();
    }

    [HttpDelete("{toDoItemId:int}")]
    public IActionResult DeleteById(int toDoItemId)
    {
        try
        {
            //taky nebudu rozporovat, jen by bylo lepsi pouzit funkci Find
            //First pouzivat kdyz jsem si celkem jisty ze tam ten objekt najdu a FirstOrDefault pokud nechci odchytavat vyjimky kdyby tam nahodou nebyl
            //muze to byl lehce zavadejici pri pozdejsim cteni, ale je to funkcne v poradku :)
            var item = Items.FirstOrDefault(i => i.ToDoItemId == toDoItemId);
            if (item == null)
            {
                return NotFound();
            }

            Items.Remove(item);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);

        }
        return NoContent();
    }
}
