# etnguyen03/opendental

This is a fork of [opendental/opendental](https://github.com/OpenDental/opendental/tree/24_3), version 24.3, [the last GPL version distributed](https://www.opendental.com/site/distributors.html).

The eventual goal of this fork is to simply make Open Dental easier to develop on.
I have had several thoughts regarding the development of Open Dental that I have wanted to make OSS, but simply do not have the time to
maintain several new versions of whenever a new version of Open Dental is released. Now that Open Dental has gone proprietary, I can more easily
maintain this fork instead of having to rebase my changes on every single new version released.

My goals include:

* Get something building on Linux.
* A more easily deployable "server" concept on Linux (i.e. publish my k8s deployment that I use)
* CI/CD.
* The removal of "database integrity" features, which are by their nature ["security by obscurity"](https://en.wikipedia.org/wiki/Security_through_obscurity), and stifle competition.
    * Database integrity should be handled through strict controls over who writes to the database (i.e. endpoint security, using the "middle end" with TLS certifiate authentication on both ends),
      instead of complaining when a malicious actor hasn't gone through the trouble of decompiling a DLL file
      to figure out what the "security hash" should be changed to.
* The removal of all cloud services. I don't use them, and they arguably belong separate from a desktop office management software, not built in.

---

The original code on which this repository is based out of
is Open Dental, Copyright 2003-2024, Jordan S. Sparks, DMD.
It is used in accordance with version 2 of the GNU General Public License,
as published by the Free Software Foundation.

---

Copyright (C) 2025 Ethan Nguyen and contributors.

This program is free software; you can redistribute it and/or modify
it under the terms of version 2 of the the GNU General Public
License as published by the Free Software Foundation.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.