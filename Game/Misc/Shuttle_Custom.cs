// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Shuttle_Custom : Shuttle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "custom shuttle";
			this.dir = 2;
		}

		public Shuttle_Custom ( dynamic starting_area = null ) : base( (object)(starting_area) ) {
			
		}

	}

}