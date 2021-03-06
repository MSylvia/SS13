// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Mecha_Combat_Gygax_Dark : Obj_Mecha_Combat_Gygax {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.deflect_chance = 15;
			this.damage_absorption = new ByTable().Set( "brute", 0.6 ).Set( "fire", 0.8 ).Set( "bullet", 0.6 ).Set( "laser", 0.5 ).Set( "energy", 0.41 ).Set( "bomb", 0.8 );
			this.max_temperature = 35000;
			this.leg_overload_coeff = 1;
			this.operation_req_access = new ByTable(new object [] { 150 });
			this.wreckage = typeof(Obj_Structure_MechaWreckage_Gygax_Dark);
			this.max_equip = 4;
			this.icon_state = "darkgygax";
		}

		public Obj_Mecha_Combat_Gygax_Dark ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: gygax.dm
		public override void RemoveActions( Ent_Static user = null, bool? human_occupant = null ) {
			human_occupant = human_occupant ?? false;

			base.RemoveActions( user, human_occupant );
			this.thrusters_action.Remove( user );
			return;
		}

		// Function from file: gygax.dm
		public override void GrantActions( Ent_Static user = null, bool? human_occupant = null ) {
			human_occupant = human_occupant ?? false;

			base.GrantActions( user, human_occupant );
			this.thrusters_action.chassis = this;
			this.thrusters_action.Grant( user );
			return;
		}

		// Function from file: gygax.dm
		public override void add_cell( Ent_Dynamic C = null ) {
			
			if ( C != null ) {
				C.forceMove( this );
				this.cell = C;
				return;
			}
			this.cell = new Obj_Item_Weapon_StockParts_Cell( this );
			this.cell.charge = 30000;
			this.cell.maxcharge = 30000;
			return;
		}

	}

}