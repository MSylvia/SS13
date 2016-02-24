// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AmContainment : Obj_Item_Weapon {

		public int fuel = 10000;
		public int fuel_max = 10000;
		public int stability = 100;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 8;
			this.throwforce = 10;
			this.throw_speed = 1;
			this.throw_range = 2;
			this.icon = "icons/obj/machines/antimatter.dmi";
			this.icon_state = "jar";
		}

		public Obj_Item_Weapon_AmContainment ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: containment_jar.dm
		public int usefuel( int wanted = 0 ) {
			
			if ( this.fuel < wanted ) {
				wanted = this.fuel;
			}
			this.fuel -= wanted;
			return wanted;
		}

		// Function from file: containment_jar.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.explosion( GlobalFuncs.get_turf( this ), 1, 2, 3, 5 );

					if ( this != null ) {
						GlobalFuncs.qdel( this );
					}
					break;
				case 2:
					
					if ( Rand13.PercentChance( ((int)( this.fuel / 10 - this.stability )) ) ) {
						GlobalFuncs.explosion( GlobalFuncs.get_turf( this ), 1, 2, 3, 5 );

						if ( this != null ) {
							GlobalFuncs.qdel( this );
						}
						return false;
					}
					this.stability -= 40;
					break;
				case 3:
					this.stability -= 20;
					break;
			}
			return false;
		}

	}

}