// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher : Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic {

		public double? missile_speed = 2;
		public double? missile_range = 30;

		public Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: weapons.dm
		public virtual void proj_init( dynamic O = null ) {
			return;
		}

		// Function from file: weapons.dm
		[VerbInfo( name: "action" )]
		public override bool f_action( dynamic target = null ) {
			dynamic O = null;

			
			if ( !this.action_checks( target ) ) {
				return false;
			}
			O = Lang13.Call( this.projectile, this.chassis.loc );
			GlobalFuncs.playsound( this.chassis, this.fire_sound, 50, 1 );
			this.log_message( "Launched a " + O.name + " from " + this.name + ", targeting " + target + "." );
			this.projectiles--;
			this.proj_init( O );
			((Ent_Dynamic)O).throw_at_fast( target, this.missile_range, this.missile_speed, null, false );
			return true;
		}

	}

}