// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Antibodies : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.data = new ByTable().Set( "antibodies", 0 );
			this.name = "Antibodies";
			this.id = "antibodies";
			this.reagent_state = 2;
			this.color = "#0050F0";
		}

		// Function from file: antibodies.dm
		public override bool reaction_mob( dynamic M = null, int? method = null, double volume = 0 ) {
			method = method ?? GlobalVars.TOUCH;

			
			if ( M is Mob_Living_Carbon ) {
				
				if ( Lang13.Bool( this.data ) && method == GlobalVars.INGEST ) {
					
					if ( Lang13.Bool( M.virus2 ) ) {
						
						if ( Lang13.Bool( this.data["antibodies"] & M.virus2.antigen ) ) {
							M.virus2.dead = 1;
						}
					}
					M.antibodies = ((int)( M.antibodies )) | ( Convert.ToInt32( this.data["antibodies"] ) );
				}
			}
			return false;
		}

	}

}