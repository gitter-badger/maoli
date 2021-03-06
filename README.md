# Maoli

[![Build Status](https://travis-ci.org/aueda/maoli.svg?branch=master)](https://travis-ci.org/aueda/maoli/)
[![NuGet Version](https://img.shields.io/nuget/v/Maoli.svg)](https://www.nuget.org/packages/Maoli/)

Versão em português: [LEIAME.md](https://github.com/aueda/maoli/blob/master/LEIAME.md)

Maoli is C# helper library for common brazilian business rules (CEP, CPF and CNPJ),
compatible with .NET Framework 4.0 and above.

Currently implements:

* CEP validation
* CPF validation
* CNPJ validation

For client-side validation of CPF and CNPJ, please see [Maoli.js](https://github.com/aueda/maoli.js/).

## Documentation

### Cep

``Cep.Validate(string value)`` - checks if a string value is a valid CEP representation. Returns true if CEP string is valid; false otherwise.

```c#
if (Cep.Validate("99999-999"))
{
  Console.WriteLine("CEP is valid");
}
```

### Cpf

``Cpf.Validate(string value)`` - checks if a string value is a valid CPF representation. Returns true if CPF string is valid; false otherwise.

```c#
if (Cpf.Validate("999.999.99-99"))
{
  Console.WriteLine("CPF is valid");
}
```

``Cpf.Complete(string value)`` - completes a partial CPF string by appending a valid checksum trailing.
Returns a CPF string with a valid checksum trailing.

```c#
// outputs "99999999999"
var cpf = Cpf.Complete("99999999"));
```

### Cnpj

``Cnpj.Validate(string value)`` - checks if a string value is a valid CNPJ representation. Returns true if CNPJ string is valid; false otherwise.

```c#
if (Cnpj.Validate("99.999.999/9999-99"))
{
  Console.WriteLine("CPNJ is valid");
}
```
``Cnpj.Complete(string value)`` - completes a partial CNPJ string by appending a valid checksum trailing.
Returns a CNPJ string with a valid checksum trailing.

```c#
// outputs "99999999999999"
var cnpj = Cnpj.Complete("999999999999"));
```

## NuGet Package

To install Maoli using NuGet, run the following command in the Package Manager Console:

```
Install-Package Maoli
```

See the [NuGet website](https://www.nuget.org/packages/Maoli/).

## Source Code

Source code is available at [GitHub](https://github.com/aueda/maoli/).

## License

This project is licensed under the [MIT License](http://opensource.org/licenses/MIT).

## Author

Adriano Ueda [@adriueda](https://twitter.com/adriueda)