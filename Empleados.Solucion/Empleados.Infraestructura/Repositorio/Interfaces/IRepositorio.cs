﻿using System.Linq.Expressions;

namespace Empleados.Infraestructura.Repositorio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodos(
            Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string incluirPropiedades = null
            );

        Task<T> ObtenerPrimero(
            Expression<Func<T, bool>> filtro = null,
            string incluirPropiedades = null
           );

        Task Agregar(T entidad);
        void Remover(T entidad);
        Task Guardar();
    }
}
