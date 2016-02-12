// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_CoreSampler : Obj_Item_Device {

		public string sampled_turf = "";
		public int num_stored_bags = 10;
		public Obj_Item_Weapon_Evidencebag filled_bag = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "screwdriver_brown";
			this.w_class = 1;
			this.icon_state = "sampler0";
		}

		public Obj_Item_Device_CoreSampler ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tools_coresampler.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic success = null;
			Ent_Static M = null;

			
			if ( this.filled_bag != null ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'>You eject the full sample bag.</span>" );
				success = 0;

				if ( this.loc is Mob ) {
					M = this.loc;
					success = ((dynamic)M).put_in_inactive_hand( this.filled_bag );
				}

				if ( !Lang13.Bool( success ) ) {
					this.filled_bag.loc = GlobalFuncs.get_turf( this );
				}
				this.filled_bag = null;
				this.icon_state = "sampler0";
			} else {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>The core sampler is empty.</span>" );
			}
			return null;
		}

		// Function from file: tools_coresampler.dm
		public void sample_item( Ent_Static item_to_sample = null, dynamic user = null ) {
			dynamic geo_data = null;
			Ent_Static T = null;
			Ent_Static O = null;
			Obj_Item_Weapon_Rocksliver R = null;
			Image I = null;

			
			if ( item_to_sample is Tile_Unsimulated_Mineral ) {
				T = item_to_sample;
				((Geosample)((dynamic)T).geologic_data).UpdateNearbyArtifactInfo( T );
				geo_data = ((dynamic)T).geologic_data;
			} else if ( item_to_sample is Obj_Item_Weapon_Strangerock ) {
				O = item_to_sample;
				geo_data = ((dynamic)O).geologic_data;
			}

			if ( Lang13.Bool( geo_data ) ) {
				
				if ( this.filled_bag != null ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>The core sampler is full!</span>" );
				} else if ( this.num_stored_bags < 1 ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>The core sampler is out of sample bags!</span>" );
				} else {
					this.filled_bag = new Obj_Item_Weapon_Evidencebag( this );
					this.filled_bag.name = "sample bag";
					this.filled_bag.desc = "a bag for holding research samples.";
					this.icon_state = "sampler1";
					this.num_stored_bags--;
					R = new Obj_Item_Weapon_Rocksliver();
					R.geological_data = geo_data;
					R.loc = this.filled_bag;
					this.filled_bag.icon_state = "evidence";
					I = new Image( R, null, null, GlobalVars.FLOAT_LAYER );
					this.filled_bag.underlays.Add( I );
					this.filled_bag.w_class = 1;
					GlobalFuncs.to_chat( user, "<span class='notice'>You take a core sample of the " + item_to_sample + ".</span>" );
				}
			} else {
				GlobalFuncs.to_chat( user, "<span class='warning'>You are unable to take a sample of " + item_to_sample + ".</span>" );
			}
			return;
		}

		// Function from file: tools_coresampler.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Evidencebag ) {
				
				if ( this.num_stored_bags < 10 ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You insert the " + a + " into the core sampler.</span>" );
					GlobalFuncs.qdel( a );
					a = null;
					this.num_stored_bags += 1;
					return 1;
				} else {
					GlobalFuncs.to_chat( b, "<span class='warning'>The core sampler can not fit any more bags!</span>" );
				}
			} else {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: tools_coresampler.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( Map13.GetDistance( this, user ) < 2 ) {
				GlobalFuncs.to_chat( user, "<span class='info'>This one is " + ( Lang13.Bool( this.sampled_turf ) ? "full" : "empty" ) + ", and has " + this.num_stored_bags + " bag" + ( this.num_stored_bags != 1 ? "s" : "" ) + " remaining.</span>" );
			}
			return null;
		}

	}

}