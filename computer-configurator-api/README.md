# Computer Configurator RESTful API

The glue between the database and web application; the 'middle layer' of the software stack.
Responsible for communicating with the database and providing an appropriate response.

## Dependencies

### Npgsql.EntityFrameworkCore.PostgreSQL [(Website)](https://www.npgsql.org/) [(NuGet)](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/7.0.0-preview.6) [(GitHub)](https://github.com/npgsql/efcore.pg):
**(Entity Framework Core 6.0)**

The major dependency for this project, providing the 'data access layer'.
Npgsql provides communnication with PostgreSQL databases; and EntityFrameworkCore provides Object-Relational-Mapping.
Eventually as queries become more complex for a combination of highly normalised data (eg. the 'System' entity),
raw SQL querying functionality built in to EF Core may be used for increasing performance.

### Konscious.Security.Cryptography.Argon2 [(NuGet)](https://www.nuget.org/packages/Konscious.Security.Cryptography.Argon2) [(GitHub)](https://github.com/P-H-C/phc-winner-argon2):
Provides use of the Argon2id password-based key derivation function.
Argon2 was the winner of the 2015 Password Hashing Competition.

Argon2d claims to be '[memory-hard](https://en.wikipedia.org/wiki/Memory-hard_function)'; meaning it provides sufficient protection against GPU brute-force attacks.
It does so by using enough memory to stress the GPU's' cache-per-core, slowing down the rate of rainbow-table generation.

Argon2i claims to be resistant to '[side-channel attacks](https://en.wikipedia.org/wiki/Side-channel_attack)'.
A side channel attack occurs when a secret is derived via a cache, timing, or differential fault attack.
These are less commonly used, though covering all bases cannot be a bad thing.

Argon2id is the combination of these functions; claiming protection against both.
7 years is a short timespan for a new PBKDF to be sufficiently vetted as 'secure', though I trust it enough.

---

You can contact me at: sunny73cr@protonmail.com

---

MIT License

Copyright (c) 2021 Dylan Avery

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
