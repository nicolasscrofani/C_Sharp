﻿/*
 * MIT License
 * 
 * Copyright (c) 2021 [FacuFalcone]
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace CentralitaHerencia {
    public sealed class Provincial : Llamada {
        private Franja franjaHoraria;

        public enum Franja {
            Franja_01,
            Franja_02,
            Franja_03
        }

        #region Properties

        /// <summary>
        /// Get: Gets the total price of the call.
        /// </summary>
        public float CostoLlamada { get => CalcularCostos(); }

        #endregion

        #region Builders

        /// <summary>
        /// Builds the entity with all its parameters.
        /// </summary>
        /// <param name="call">Llamada-type object.</param>
        /// <param name="franjaHoraria">Time zone of the call.</param>
        public Provincial(Llamada call, Franja franjaHoraria)
            : base(call.Duracion, call.NroOrigen, call.NroDestino) {
            this.franjaHoraria = franjaHoraria;
        }

        /// <summary>
        /// Builds the entity with all its parameters.
        /// </summary>
        /// <param name="duracion">Duration of the call.</param>
        /// <param name="origen">Origin of the call.</param>
        /// <param name="destino">Destiny of the call.</param>
        /// <param name="franjaHoraria">Time zone of the call.</param>
        public Provincial(float duracion, string origen, string destino, Franja franjaHoraria)
            : this(new Llamada(duracion, origen, destino), franjaHoraria) { }

        #endregion

        #region Methods

        /// <summary>
        /// It will caltulate the cost of the call, based in the duration and its price.
        /// </summary>
        /// <returns>The cost of the call.</returns>
        private float CalcularCostos() {
            float price = 0;
            if (this.franjaHoraria == Franja.Franja_01) {
                price = 0.99F;
            } else if (this.franjaHoraria == Franja.Franja_02) {
                price = 1.25F;
            } else {
                price = 0.66F;
            }

            return base.Duracion * price;
        }

        /// <summary>
        /// Shows the info of the call.
        /// </summary>
        /// <returns>Returns the info as a string.</returns>
        public override string Mostrar() {
            string data = string.Format("{0}", base.Mostrar());
            data += string.Format("Costo: ${0,3}\n", this.CostoLlamada);

            return data;
        }

        #endregion
    }
}
