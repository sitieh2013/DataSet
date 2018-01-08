using System;
using System.Collections.Generic;
using ClassMiBlog.AdoNet;
using ClassMiBlog.Entities;

namespace ClassMiBlog.Repository
{
    public sealed class RepositoryEngineering :  IRepositoryEngineering
    {
        private readonly CommandContext _context;

        public RepositoryEngineering()
        {
            _context = new CommandContext();
        }

        public RepositoryEngineering(EnumDataProvider provider)
        {
            _context = new CommandContext(provider);
        }

        public void Insert(Engineering entidad)
        {
            _context.DbContext.ExecuteComand("InsertEngineering",
                new []
                {
                    new ParameterCommon { Name = "@Name", Value = entidad.Name }
                });
        }

        public void Delete(Engineering entidad)
        {
            _context.DbContext.ExecuteComand("InsertEngineering", 
                new[]
                {
                    new ParameterCommon { Name = "@Id", Value = entidad.Id }
                });
        }

        public void Update(Engineering entidad)
        {
            _context.DbContext.ExecuteComand("InsertEngineering",
                new[]
                {
                    new ParameterCommon { Name = "@Name", Value = entidad.Name },
                    new ParameterCommon { Name = "@Id", Value = entidad.Id }
                });
        }

        public IEnumerable<Engineering> FindAll()
        {
            return MapperEngineering.Convert(_context.DbContext.Fill("SelectAllEngineering"));
        }
    }
}
