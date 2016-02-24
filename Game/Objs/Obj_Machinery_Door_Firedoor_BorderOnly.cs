// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Firedoor_BorderOnly : Obj_Machinery_Door_Firedoor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 512;
			this.icon = "icons/obj/doors/edge_Doorfire.dmi";
		}

		public Obj_Machinery_Door_Firedoor_BorderOnly ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: firedoor.dm
		public override bool CanAtmosPass( dynamic T = null ) {
			
			if ( Map13.GetDistance( this.loc, T ) == this.dir ) {
				return !this.density;
			} else {
				return true;
			}
		}

		// Function from file: firedoor.dm
		public override bool CheckExit( Ent_Dynamic mover = null, Tile target = null ) {
			
			if ( mover is Ent_Dynamic && mover.checkpass( 2 ) != 0 ) {
				return true;
			}

			if ( Map13.GetDistance( this.loc, target ) == this.dir ) {
				return !this.density;
			} else {
				return true;
			}
		}

		// Function from file: firedoor.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( mover is Ent_Dynamic && ((Ent_Dynamic)mover).checkpass( 2 ) != 0 ) {
				return true;
			}

			if ( Map13.GetDistance( this.loc, target ) == this.dir ) {
				return !this.density;
			} else {
				return true;
			}
		}

	}

}