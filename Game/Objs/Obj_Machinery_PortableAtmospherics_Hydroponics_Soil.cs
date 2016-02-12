// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_PortableAtmospherics_Hydroponics_Soil : Obj_Machinery_PortableAtmospherics_Hydroponics {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.draw_warnings = false;
			this.icon_state = "soil";
		}

		// Function from file: soil.dm
		public Obj_Machinery_PortableAtmospherics_Hydroponics_Soil ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.verbs.Remove( typeof(Obj_Machinery_PortableAtmospherics_Hydroponics).GetMethod( "close_lid" ) );
			this.verbs.Remove( typeof(Obj_Machinery_PortableAtmospherics_Hydroponics).GetMethod( "set_label" ) );
			this.verbs.Remove( typeof(Obj_Machinery_PortableAtmospherics_Hydroponics).GetMethod( "light_toggle" ) );
			this.component_parts = new ByTable();
			return;
		}

		// Function from file: soil.dm
		public override void smashDestroy( int? destroy_chance = null ) {
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: soil.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Pickaxe_Shovel ) {
				
				if ( !( this.seed != null ) ) {
					GlobalFuncs.to_chat( b, "You clear up " + this + "!" );
					new Obj_Item_Weapon_Ore_Glass( this.loc );
					new Obj_Item_Weapon_Ore_Glass( this.loc );
					GlobalFuncs.qdel( this );
					return 1;
				} else {
					base.attackby( (object)(a), (object)(b), (object)(c) );
				}
			} else {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

	}

}