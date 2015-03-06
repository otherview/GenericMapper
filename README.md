# GenericMapper
A c# generic mapper for DB reads.

This is just a simple mapper that maps the Model to the Database using Reflection.


###Model usage :
`[GetFromDBAttribute(true, databaseType: typeof(DATATYPE), databaseName: "DB FIELD NAME")]`

###Usage:


Initialize. Reads the Class and builds a dictionary based on the class's Costum Attribute Properties:

`GenericMapper<Taxes> taxRowMapper = new GenericMapper<Taxes>();`

Returns the new mapped instatiation of the class:

`Taxes tax = taxRowMapper.MapRow<Taxes>(reader);`




TODO : A smiliar writer Mapper
