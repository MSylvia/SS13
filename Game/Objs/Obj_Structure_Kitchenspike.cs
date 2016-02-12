// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Kitchenspike : Obj_Structure {

		public Mob occupant = null;
		public dynamic meat_remaining = 0;
		public ByTable allowed_mobs = new ByTable()
											.Set( typeof(Mob_Living_Carbon_Monkey_Diona), "spikebloodynymph" )
											.Set( typeof(Mob_Living_Carbon_Monkey), "spikebloody" )
											.Set( typeof(Mob_Living_Carbon_Alien), "spikebloodygreen" )
											.Set( typeof(Mob_Living_SimpleAnimal_Hostile_Alien), "spikebloodygreen" )
										;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/kitchen.dmi";
			this.icon_state = "spike";
		}

		public Obj_Structure_Kitchenspike ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: kitchen_spike.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}

			if ( this.occupant != null ) {
				
				if ( Convert.ToDouble( this.meat_remaining ) > 0 ) {
					this.meat_remaining--;
					((Mob_Living)this.occupant).drop_meat( GlobalFuncs.get_turf( this ) );

					if ( Lang13.Bool( this.meat_remaining ) ) {
						GlobalFuncs.to_chat( a, new Txt( "You remove some meat from " ).the( this.occupant ).item().str( "." ).ToString() );
					} else {
						GlobalFuncs.to_chat( a, new Txt( "You remove the last piece of meat from " ).the( this ).item().str( "!" ).ToString() );
						this.clean();
					}
				}
			} else {
				this.clean();
			}
			return null;
		}

		// Function from file: kitchen_spike.dm
		public void clean(  ) {
			this.icon_state = Lang13.Initial( this, "icon_state" );

			if ( this.occupant != null ) {
				GlobalFuncs.qdel( this.occupant );
				this.occupant = null;
			}
			this.meat_remaining = 0;
			return;
		}

		// Function from file: kitchen_spike.dm
		public void handleGrab( dynamic G = null, dynamic user = null ) {
			Mob our_mob = null;
			dynamic T = null;

			
			if ( !( G is Obj_Item_Weapon_Grab ) ) {
				return;
			}
			our_mob = G.affecting;

			if ( !( our_mob is Mob_Living ) ) {
				return;
			}

			if ( this.occupant != null ) {
				GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>" ).item( this.occupant.name ).str( " is already hanging from " ).the( this ).item().str( ", finish collecting its meat first!</span>" ).ToString() );
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.allowed_mobs )) {
				T = _a;
				

				if ( Lang13.Bool( T.IsInstanceOfType( our_mob ) ) ) {
					
					if ( our_mob.abiotic() ) {
						GlobalFuncs.to_chat( user, "<span class='warning'>Subject may not have abiotic items on.</span>" );
						return;
					} else {
						this.occupant = our_mob;

						if ( Lang13.Bool( this.allowed_mobs[T] ) ) {
							this.icon_state = this.allowed_mobs[T];
						} else {
							this.icon_state = "spikebloody";
						}
						this.meat_remaining = our_mob.size + 1 - ((dynamic)our_mob).meat_taken;
						((Ent_Static)user).visible_message( "<span class='warning'>" + user + " has forced " + our_mob + " onto the spike, killing it instantly!</span>" );
						our_mob.death( false );
						our_mob.ghostize();
						our_mob.forceMove( this );
						GlobalFuncs.returnToPool( G );
						return;
					}
				}
			}
			return;
		}

		// Function from file: kitchen_spike.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Game_Data M = null;

			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_Weapon_Wrench ) {
				
				if ( this.occupant != null ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>You can't disassemble " + this + " with meat and gore all over it.</span>" );
					return null;
				}
				M = GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Metal), GlobalFuncs.get_turf( this ) );
				((dynamic)M).amount = 2;
				GlobalFuncs.qdel( this );
				return null;
			}

			if ( a is Obj_Item_Weapon_Grab ) {
				this.handleGrab( a, b ); return null;
			}
			return null;
		}

		// Function from file: kitchen_spike.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( Task13.User );
		}

	}

}