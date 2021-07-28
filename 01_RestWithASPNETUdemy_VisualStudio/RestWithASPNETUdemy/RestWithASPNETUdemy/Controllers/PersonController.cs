using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CalculatorController : ControllerBase
  {


    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid Input");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid Input");
    }

    [HttpGet("average/{firstNumber}/{secondNumber}")]
    public IActionResult Average(string firstNumber, string secondNumber)
    {
      if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
      {
        var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid Input");
    }

    [HttpGet("square-root/{firstNumber}")]
    public IActionResult SquareRoot(string firstNumber)
    {
      if (IsNumeric(firstNumber))
      {
        var sum = Math.Sqrt((double)ConvertToDecimal(firstNumber));
        return Ok(sum.ToString());
      }
      return BadRequest("Invalid Input");
    }

    private decimal ConvertToDecimal(string strNumber)
    {
      decimal decimalValue;
      if (decimal.TryParse(strNumber, out decimalValue))
      {
        return decimalValue;
      }
      return 0;
    }

    private bool IsNumeric(string strNumber)
    {
      double number;
      bool isNumber = double.TryParse(
           strNumber, System.Globalization.NumberStyles.Any,
           System.Globalization.NumberFormatInfo.InvariantInfo,
           out number);
      return isNumber;
      throw new NotImplementedException();
    }
  }
}
