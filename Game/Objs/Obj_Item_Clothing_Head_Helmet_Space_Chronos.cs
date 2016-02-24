// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Chronos : Obj_Item_Clothing_Head_Helmet_Space {

		public Obj_Item_Clothing_Suit_Space_Chronos suit = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "chronohelmet";
			this.slowdown = 1;
			this.armor = new ByTable().Set( "melee", 60 ).Set( "bullet", 30 ).Set( "laser", 60 ).Set( "energy", 60 ).Set( "bomb", 30 ).Set( "bio", 90 ).Set( "rad", 90 );
			this.icon_state = "chronohelmet";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Chronos ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: chronosuit.dm
		public override dynamic Destroy(  ) {
			this.dropped();
			return base.Destroy();
		}

		// Function from file: chronosuit.dm
		public override bool dropped( dynamic user = null ) {
			
			if ( this.suit != null ) {
				this.suit.deactivate();
			}
			base.dropped( (object)(user) );
			return false;
		}

	}

}