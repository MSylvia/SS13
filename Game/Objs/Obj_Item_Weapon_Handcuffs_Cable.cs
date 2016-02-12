// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Handcuffs_Cable : Obj_Item_Weapon_Handcuffs {

		protected override void __FieldInit() {
			base.__FieldInit();

			this._color = "red";
			this.breakouttime = 300;
			this.icon_state = "cuff_red";
		}

		public Obj_Item_Weapon_Handcuffs_Cable ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: handcuffs.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic R = null;
			Obj_Item_Weapon_Wirerod W = null;

			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_Stack_Rods ) {
				R = a;
				W = new Obj_Item_Weapon_Wirerod();
				((Obj_Item_Stack)R).use( 1 );
				((Mob)b).before_take_item( this );
				((Mob)b).put_in_hands( W );
				GlobalFuncs.to_chat( b, "<span class='notice'>You wrap the cable restraint around the top of the rod.</span>" );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: handcuffs.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( Lang13.Bool( this._color ) ) {
				this.icon_state = "cuff_" + this._color;
			}
			return null;
		}

	}

}