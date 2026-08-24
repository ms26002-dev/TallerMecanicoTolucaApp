using System;
using System.Collections.Generic;
using System.IO;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class InventarioBL
    {
        private readonly InventarioDAL _inventarioDAL = new InventarioDAL();

        public List<RepuestoEN> ObtenerRepuestos()
        {
            return _inventarioDAL.ObtenerRepuestos();
        }

        public List<MovimientoInventarioEN> ObtenerMovimientos()
        {
            return _inventarioDAL.ObtenerMovimientos();
        }

        public int RegistrarRepuesto(RepuestoEN repuesto)
        {
            if (string.IsNullOrWhiteSpace(repuesto.Codigo) || string.IsNullOrWhiteSpace(repuesto.NombreRepuesto))
                throw new ArgumentException("El código y el nombre del repuesto son obligatorios.");

            if (repuesto.PrecioUnitario <= 0)
                throw new ArgumentException("El precio unitario debe ser mayor a cero.");

            return _inventarioDAL.RegistrarRepuesto(repuesto);
        }

        public int ActualizarRepuesto(RepuestoEN repuesto)
        {
            if (repuesto.RepuestoID <= 0)
                throw new ArgumentException("ID de repuesto inválido.");

            if (string.IsNullOrWhiteSpace(repuesto.Codigo) || string.IsNullOrWhiteSpace(repuesto.NombreRepuesto))
                throw new ArgumentException("El código y el nombre del repuesto son obligatorios.");

            if (repuesto.PrecioUnitario <= 0)
                throw new ArgumentException("El precio unitario debe ser mayor a cero.");

            return _inventarioDAL.ActualizarRepuesto(repuesto);
        }

        public int EliminarRepuesto(int repuestoId)
        {
            if (repuestoId <= 0)
                throw new ArgumentException("ID de repuesto inválido.");

            return _inventarioDAL.EliminarRepuesto(repuestoId);
        }

        public int RegistrarMovimiento(MovimientoInventarioEN mov)
        {
            if (mov.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

            // Restricción #7: Las salidas de inventario deben estar justificadas por uso en taller
            if (mov.TipoMovimiento == "Salida" && string.IsNullOrWhiteSpace(mov.Motivo))
            {
                throw new ArgumentException("Las salidas de repuestos deben registrar el motivo u orden de trabajo asociada.");
            }

            return _inventarioDAL.RegistrarMovimiento(mov);
        }

        public int EliminarMovimiento(int movimientoId)
        {
            if (movimientoId <= 0)
                throw new ArgumentException("ID de movimiento inválido.");

            return _inventarioDAL.EliminarMovimiento(movimientoId);
        }

        public int ImportarRepuestosDesdeCSV(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException("El archivo CSV no fue encontrado.");

            int importados = 0;
            string[] lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
            {
                if (string.IsNullOrWhiteSpace(linea) || linea.StartsWith("Codigo") || linea.StartsWith("Código"))
                    continue;

                string[] partes = linea.Split(',', ';');
                if (partes.Length >= 4)
                {
                    try
                    {
                        RepuestoEN repuesto = new RepuestoEN
                        {
                            Codigo = partes[0].Trim(),
                            NombreRepuesto = partes[1].Trim(),
                            PrecioUnitario = Convert.ToDecimal(partes[2].Trim().Replace("$", "")),
                            Existencia = Convert.ToInt32(partes[3].Trim())
                        };

                        RegistrarRepuesto(repuesto);
                        importados++;
                    }
                    catch
                    {
                        // Si falla una línea (ej. duplicado), continuar con las siguientes
                    }
                }
            }

            return importados;
        }
    }
}