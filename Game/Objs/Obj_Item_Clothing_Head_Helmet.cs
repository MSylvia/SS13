// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "helmet";
			this.armor = new ByTable().Set( "melee", 50 ).Set( "bullet", 15 ).Set( "laser", 50 ).Set( "energy", 10 ).Set( "bomb", 25 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.body_parts_covered = 10241;
			this.heat_conductivity = 0.4;
			this.max_heat_protection_temperature = 600;
			this.siemens_coefficient = 061;
			this.icon_state = "helmet";
		}

		public Obj_Item_Clothing_Head_Helmet ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: secbot.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Item_Weapon_SecbotAssembly A = null;

			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( !GlobalFuncs.issignaler( a ) ) {
				base.attackby( (object)(a), (object)(b), (object)(c) );
				return null;
			}

			if ( this.type != typeof(Obj_Item_Clothing_Head_Helmet) ) {
				return null;
			}

			if ( Lang13.Bool( a.secured ) ) {
				GlobalFuncs.qdel( a );
				A = new Obj_Item_Weapon_SecbotAssembly();
				((Mob)b).put_in_hands( A );
				GlobalFuncs.to_chat( b, "You add the signaler to the helmet." );
				((Mob)b).drop_from_inventory( this );
				GlobalFuncs.qdel( this );
			} else {
				return null;
			}
			return null;
		}

	}

}