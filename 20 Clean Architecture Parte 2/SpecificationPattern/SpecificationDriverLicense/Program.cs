


using SpecificationDriverLicense;
using System.Text.Json;

int edadParaEvaluar = 27;
var person = new PersonModel
{
    Altura = 6,
    Id = 1,
    Edad = 24,
    Nombre = "Vaxi Drez"
};

var result = EvaluateDriverLicenseByEdad(edadParaEvaluar, person) ? $"{person.Nombre} obtuvo la licencia" : "Licencia negada";
Console.Write(result);



bool EvaluateDriverLicenseByEdad(int edadParaEvaluar, PersonModel personModel)
{
    var specification = new DriverLicenseBySpecification(edadParaEvaluar);
    return specification.IsCumpleReglas(personModel);
}


var personData = File.ReadAllText(@"person.json");
var persons = JsonSerializer.Deserialize<List<PersonModel>>(personData);

var personsWithLicense = EvaluateCollectionPersonByLicenseDriver(persons, edadParaEvaluar);
personsWithLicense.ToList().ForEach(person => Console.WriteLine($"{person.Nombre} {person.Edad}  obtuvo la licencia"));

IEnumerable<PersonModel> EvaluateCollectionPersonByLicenseDriver(IEnumerable<PersonModel> personsModel, int edadParaEvaluar)
{
    return  personsModel.Where(x => EvaluateDriverLicenseByEdad(edadParaEvaluar, x));
}
