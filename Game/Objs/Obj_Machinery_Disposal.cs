// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Disposal : Obj_Machinery {

		public GasMixture air_contents = null;
		public dynamic mode = 1;
		public dynamic flush = 0;
		public dynamic trunk = null;
		public bool flushing = false;
		public int flush_every_ticks = 30;
		public int flush_count = 0;
		public int last_sound = 0;
		public Ent_Static stored = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/atmospherics/pipes/disposal.dmi";
		}

		// Function from file: disposal-unit.dm
		public Obj_Machinery_Disposal ( dynamic loc = null, Obj_Structure_Disposalconstruct make_from = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( make_from != null ) {
				this.dir = make_from.dir;
				make_from.loc = loc;
				this.stored = make_from;
			} else {
				this.stored = new Obj_Structure_Disposalconstruct(loc, 6, this.dir );
			}
			this.trunk_check();
			this.air_contents = new GasMixture();
			this.update();
			return;
		}

		// Function from file: disposal-unit.dm
		public override bool storage_contents_dump_act( Obj_Item_Weapon_Storage src_object = null, Mob user = null ) {
			Obj_Item I = null;

			
			foreach (dynamic _a in Lang13.Enumerate( src_object, typeof(Obj_Item) )) {
				I = _a;
				

				if ( user.s_active != src_object ) {
					
					if ( I.on_found( user ) ) {
						return false;
					}
				}
				src_object.remove_from_storage( I, this );
			}
			return true;
		}

		// Function from file: disposal-unit.dm
		public override void Deconstruct(  ) {
			Ent_Static T = null;

			
			if ( this.stored != null ) {
				T = this.loc;
				this.stored.loc = T;
				this.transfer_fingerprints_to( this.stored );
				((dynamic)this.stored).anchored = 0;
				this.stored.density = true;
				((Obj_Structure_Disposalconstruct)this.stored).update();
			}
			base.Deconstruct();
			return;
		}

		// Function from file: disposal-unit.dm
		public override void power_change(  ) {
			base.power_change();
			this.update();
			return;
		}

		// Function from file: disposal-unit.dm
		public override bool attack_animal( Mob_Living user = null ) {
			
			if ( Lang13.Bool( ((dynamic)user).environment_smash ) ) {
				user.do_attack_animation( this );
				this.visible_message( new Txt( "<span class='danger'>" ).item( user.name ).str( " smashes " ).the( this ).item().str( " apart!</span>" ).ToString() );
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: disposal-unit.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( Lang13.Bool( a ) && a.loc == this ) {
				Task13.User.WriteMsg( "<span class='warning'>You cannot reach the controls from inside!</span>" );
				return null;
			}
			this.interact( a, false );
			return null;
		}

		// Function from file: disposal-unit.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.interact( user, true );
			return null;
		}

		// Function from file: disposal-unit.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( ( this.stat & 1 ) != 0 ) {
				return null;
			}
			this.flush = !Lang13.Bool( this.flush );
			this.update();
			return null;
		}

		// Function from file: disposal-unit.dm
		public override void container_resist( Mob user = null ) {
			this.attempt_escape( Task13.User );
			return;
		}

		// Function from file: disposal-unit.dm
		public override bool relaymove( Mob user = null, int? direction = null ) {
			this.attempt_escape( user );
			return false;
		}

		// Function from file: disposal-unit.dm
		public override dynamic alter_health(  ) {
			return GlobalFuncs.get_turf( this );
		}

		// Function from file: disposal-unit.dm
		public override bool MouseDrop_T( Ent_Static dropping = null, Mob user = null ) {
			
			if ( dropping is Mob_Living ) {
				this.stuff_mob_in( dropping, user );
			}
			return false;
		}

		// Function from file: disposal-unit.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic W = null;

			
			if ( ( this.stat & 1 ) != 0 || !Lang13.Bool( A ) || !Lang13.Bool( user ) ) {
				return null;
			}
			this.add_fingerprint( user );

			if ( Convert.ToDouble( this.mode ) <= 0 ) {
				
				if ( A is Obj_Item_Weapon_Screwdriver ) {
					
					if ( this.contents.len > 0 ) {
						user.WriteMsg( "<span class='notice'>Eject the items first!</span>" );
						return null;
					}

					if ( this.mode == 0 ) {
						this.mode = -1;
					} else {
						this.mode = 0;
					}
					GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 50, 1 );
					user.WriteMsg( "<span class='notice'>You " + ( this.mode == 0 ? "attach" : "remove" ) + " the screws around the power connection.</span>" );
					return null;
				} else if ( A is Obj_Item_Weapon_Weldingtool && this.mode == -1 ) {
					W = A;

					if ( ((Obj_Item_Weapon_Weldingtool)W).remove_fuel( 0, user ) ) {
						
						if ( this.contents.len > 0 ) {
							user.WriteMsg( "<span class='notice'>Eject the items first!</span>" );
							return null;
						}
						GlobalFuncs.playsound( this.loc, "sound/items/welder2.ogg", 100, 1 );
						user.WriteMsg( new Txt( "<span class='notice'>You start slicing the floorweld off " ).the( this ).item().str( "...</span>" ).ToString() );

						if ( GlobalFuncs.do_after( user, 20 / A.toolspeed, null, this ) ) {
							
							if ( !((Obj_Item_Weapon_Weldingtool)W).isOn() ) {
								return null;
							}
							user.WriteMsg( new Txt( "<span class='notice'>You slice the floorweld off " ).the( this ).item().str( ".</span>" ).ToString() );
							this.Deconstruct();
						}
						return null;
					}
				}
			}
			return 1;
		}

		// Function from file: disposal-unit.dm
		public override void initialize(  ) {
			Ent_Static L = null;
			GasMixture env = null;
			GasMixture removed = null;

			L = this.loc;
			env = new GasMixture();
			env.copy_from( L.return_air() );
			removed = env.remove( 6.066249847412109 );
			this.air_contents.merge( removed );
			this.trunk_check();
			return;
		}

		// Function from file: disposal-unit.dm
		public override void singularity_pull( Obj_Singularity S = null, int? current_size = null ) {
			
			if ( ( current_size ??0) >= 9 ) {
				this.Deconstruct();
			}
			return;
		}

		// Function from file: disposal-unit.dm
		public override dynamic Destroy(  ) {
			this.eject();

			if ( Lang13.Bool( this.trunk ) ) {
				this.trunk.linked = null;
			}
			return base.Destroy();
		}

		// Function from file: disposal-unit.dm
		public void expel( Obj_Structure_Disposalholder H = null ) {
			dynamic T = null;
			Tile target = null;
			Ent_Dynamic AM = null;

			T = GlobalFuncs.get_turf( this );
			GlobalFuncs.playsound( this, "sound/machines/hiss.ogg", 50, 0, 0 );

			if ( H != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( H, typeof(Ent_Dynamic) )) {
					AM = _a;
					
					target = GlobalFuncs.get_offset_target_turf( this.loc, Rand13.Int( 5 ) - Rand13.Int( 5 ), Rand13.Int( 5 ) - Rand13.Int( 5 ) );
					AM.forceMove( T );
					AM.pipe_eject( 0 );
					AM.throw_at_fast( target, 5, 1 );
				}
				H.vent_gas( this.loc );
				GlobalFuncs.qdel( H );
			}
			return;
		}

		// Function from file: disposal-unit.dm
		public void flushAnimation(  ) {
			Icon13.Flick( "" + this.icon_state + "-flush", this );
			return;
		}

		// Function from file: disposal-unit.dm
		public virtual void newHolderDestination( Obj_Structure_Disposalholder H = null ) {
			Obj_Item_SmallDelivery O = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Item_SmallDelivery) )) {
				O = _a;
				
				H.tomail = 1;
				return;
			}
			return;
		}

		// Function from file: disposal-unit.dm
		[VerbInfo( name: "flush" )]
		public virtual void f_flush(  ) {
			Obj_Structure_Disposalholder H = null;

			this.flushing = true;
			this.flushAnimation();
			Task13.Sleep( 10 );

			if ( this.last_sound < Game13.time + 1 ) {
				GlobalFuncs.playsound( this, "sound/machines/disposalflush.ogg", 50, 0, 0 );
				this.last_sound = Game13.time;
			}
			Task13.Sleep( 5 );

			if ( Lang13.Bool( this.gc_destroyed ) ) {
				return;
			}
			H = new Obj_Structure_Disposalholder();
			this.newHolderDestination( H );
			H.init( this );
			this.air_contents = new GasMixture();
			H.start( this );
			this.flushing = false;
			this.flush = 0;
			return;
		}

		// Function from file: disposal-unit.dm
		public virtual void update(  ) {
			return;
		}

		// Function from file: disposal-unit.dm
		public void eject(  ) {
			dynamic T = null;
			Ent_Dynamic AM = null;

			T = GlobalFuncs.get_turf( this );

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Ent_Dynamic) )) {
				AM = _a;
				
				AM.forceMove( T );
				AM.pipe_eject( 0 );
			}
			this.update();
			return;
		}

		// Function from file: disposal-unit.dm
		public void go_out( Mob user = null ) {
			user.loc = this.loc;
			user.reset_perspective( null );
			this.update();
			return;
		}

		// Function from file: disposal-unit.dm
		public void attempt_escape( Mob user = null ) {
			
			if ( this.flushing ) {
				return;
			}
			this.go_out( user );
			return;
		}

		// Function from file: disposal-unit.dm
		public void stuff_mob_in( Ent_Static target = null, Mob user = null ) {
			
			if ( !( user is Mob_Living_Carbon ) && !Lang13.Bool( ((dynamic)user).ventcrawler ) ) {
				return;
			}

			if ( !( user.loc is Tile ) ) {
				return;
			}

			if ( Lang13.Bool( ((dynamic)target).buckled ) || Lang13.Bool( ((dynamic)target).buckled_mob ) ) {
				return;
			}

			if ( Convert.ToDouble( ((dynamic)target).mob_size ) > 2 ) {
				user.WriteMsg( "<span class='warning'>" + target + " doesn't fit inside " + this + "!</span>" );
				return;
			}
			this.add_fingerprint( user );

			if ( user == target ) {
				user.visible_message( "" + user + " starts climbing into " + this + ".", "<span class='notice'>You start climbing into " + this + "...</span>" );
			} else {
				target.visible_message( "<span class='danger'>" + user + " starts putting " + target + " into " + this + ".</span>", "<span class='userdanger'>" + user + " starts putting you into " + this + "!</span>" );
			}

			if ( GlobalFuncs.do_mob( user, target, 20 ) ) {
				
				if ( !( this.loc != null ) ) {
					return;
				}
				((dynamic)target).forceMove( this );

				if ( user == target ) {
					user.visible_message( "" + user + " climbs into " + this + ".", "<span class='notice'>You climb into " + this + ".</span>" );
				} else {
					target.visible_message( "<span class='danger'>" + user + " has placed " + target + " in " + this + ".</span>", "<span class='userdanger'>" + user + " has placed " + target + " in " + this + ".</span>" );
					GlobalFuncs.add_logs( user, target, "stuffed", null, "into " + this );
					((dynamic)target).LAssailant = user;
				}
				this.update();
			}
			return;
		}

		// Function from file: disposal-unit.dm
		public void trunk_check(  ) {
			this.trunk = Lang13.FindIn( typeof(Obj_Structure_Disposalpipe_Trunk), this.loc );

			if ( !Lang13.Bool( this.trunk ) ) {
				this.mode = 0;
				this.flush = 0;
			} else {
				this.mode = Lang13.Initial( this, "mode" );
				this.flush = Lang13.Initial( this, "flush" );
				this.trunk.linked = this;
			}
			return;
		}

	}

}