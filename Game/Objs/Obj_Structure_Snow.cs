// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Snow : Obj_Structure {

		public int snow_amount = 2;
		public int next_update = 0;
		public ByTable foliage = new ByTable(new object [] { "snowgrass1bb", "snowgrass2bb", "snowgrass3bb", "snowgrass1gb", "snowgrass2gb", "snowgrass3gb", "snowgrassall1", "snowgrassall2", "snowgrassall3" });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.alpha = 230;
			this.anchored = 1;
			this.icon = "icons/turf/snow.dmi";
			this.icon_state = "snow";
			this.layer = 2.5;
		}

		// Function from file: snow.dm
		public Obj_Structure_Snow ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Rand13.PercentChance( 17 ) ) {
				this.overlays.Add( new Image( "icons/obj/flora/snowflora.dmi", Rand13.PickFromTable( this.foliage ) ) );
			}
			return;
		}

		// Function from file: snow.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.snow_amount != 2 ) {
				return null;
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "rustle", 50, 1 );
			GlobalFuncs.to_chat( a, "<span class='notice'>You start digging the snow with your hands.</span>" );

			if ( GlobalFuncs.do_after( a, this, 30 ) ) {
				this.snow_amount = 1;
				GlobalFuncs.to_chat( a, "<span class='notice'>You form a snowball in your hands.</span>" );
				((Mob)a).put_in_hands( new Obj_Item_Stack_Sheet_Snow() );
				this.icon_state = "snow_grabbed";

				if ( this.snow_amount == 0 ) {
					GlobalFuncs.qdel( this );
					return null;
				}

				if ( !GlobalVars.processing_objects.Contains( this ) ) {
					GlobalVars.processing_objects.Add( this );
				}
			}
			return null;
		}

		// Function from file: snow.dm
		public override dynamic process(  ) {
			base.process();

			if ( Game13.time < this.next_update ) {
				return null;
			}

			switch ((int)( this.snow_amount )) {
				case 0:
					this.icon_state = "snow_grabbed";
					this.mouse_opacity = 1;
					this.snow_amount = 1;
					break;
				case 1:
					this.icon_state = "snow";
					this.snow_amount = 2;
					GlobalVars.processing_objects.Remove( this );
					break;
			}
			this.next_update = Game13.time + Rand13.Int( 270, 330 );
			return null;
		}

		// Function from file: snow.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Pickaxe_Shovel ) {
				GlobalFuncs.playsound( this.loc, "sound/items/shovel.ogg", 50, 1 );
				this.snow_amount = 0;
				this.icon_state = "snow_dug";
				this.mouse_opacity = 0;
				new Obj_Item_Stack_Sheet_Snow( GlobalFuncs.get_turf( this ), 1 );
				new Obj_Item_Stack_Sheet_Snow( GlobalFuncs.get_turf( this ), 1 );
				new Obj_Item_Stack_Sheet_Snow( GlobalFuncs.get_turf( this ), 1 );

				if ( this.snow_amount == 0 ) {
					GlobalFuncs.qdel( this );
					return null;
				}

				if ( !GlobalVars.processing_objects.Contains( this ) ) {
					GlobalVars.processing_objects.Add( this );
				}
			}
			return null;
		}

	}

}