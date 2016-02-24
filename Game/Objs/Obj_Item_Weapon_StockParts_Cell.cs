// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_Cell : Obj_Item_Weapon_StockParts {

		public string ratingdesc = null;
		public double? charge = 0;
		public double? maxcharge = 1000;
		public bool rigged = false;
		public int minor_fault = 0;
		public int chargerate = 100;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cell";
			this.origin_tech = "powerstorage=1";
			this.force = 5;
			this.throwforce = 5;
			this.throw_range = 5;
			this.materials = new ByTable().Set( "$metal", 700 ).Set( "$glass", 50 );
			this.icon = "icons/obj/power.dmi";
			this.icon_state = "cell";
		}

		// Function from file: cell.dm
		public Obj_Item_Weapon_StockParts_Cell ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.charge = this.maxcharge;
			this.ratingdesc = " This one has a power rating of " + this.maxcharge + ", and you should not swallow it.";
			this.desc = this.desc + this.ratingdesc;
			this.updateicon();
			return;
		}

		// Function from file: cell.dm
		public override bool blob_act( dynamic severity = null ) {
			this.ex_act( 1 );
			return false;
		}

		// Function from file: cell.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			base.ex_act( severity, (object)(target) );

			if ( !Lang13.Bool( this.gc_destroyed ) ) {
				
				switch ((int?)( severity )) {
					case 2:
						
						if ( Rand13.PercentChance( 50 ) ) {
							this.corrupt();
						}
						break;
					case 3:
						
						if ( Rand13.PercentChance( 25 ) ) {
							this.corrupt();
						}
						break;
				}
			}
			return false;
		}

		// Function from file: cell.dm
		public override double emp_act( int severity = 0 ) {
			this.charge -= 1000 / severity;

			if ( ( this.charge ??0) < 0 ) {
				this.charge = 0;
			}

			if ( this.reliability != 100 && Rand13.PercentChance( ((int)( 50 / severity )) ) ) {
				this.reliability -= 10 / severity;
			}
			base.emp_act( severity );
			return 0;
		}

		// Function from file: cell.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic S = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Weapon_ReagentContainers_Syringe ) {
				S = A;
				user.WriteMsg( "<span class='notice'>You inject the solution into the power cell.</span>" );

				if ( Lang13.Bool( ((Reagents)S.reagents).has_reagent( "plasma", 5 ) ) ) {
					this.rigged = true;
				}
				((Reagents)S.reagents).clear_reagents();
			}
			return null;
		}

		// Function from file: cell.dm
		public override int suicide_act( Mob_Living_Carbon_Human user = null ) {
			user.visible_message( new Txt( "<span class='suicide'>" ).item( user ).str( " is licking the electrodes of the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			return 2;
		}

		// Function from file: cell.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( this.crit_fail || this.rigged ) {
				user.WriteMsg( "<span class='danger'>This power cell seems to be faulty!</span>" );
			} else {
				user.WriteMsg( "The charge meter reads " + Num13.Floor( this.percent() ) + "%." );
			}
			return 0;
		}

		// Function from file: cell.dm
		public int get_electrocute_damage(  ) {
			
			if ( ( this.charge ??0) >= 1000 ) {
				return Num13.MaxInt( 10, Num13.MinInt( Num13.Floor( ( this.charge ??0) / 10000 ), 90 ) ) + Rand13.Int( -5, 5 );
			} else {
				return 0;
			}
		}

		// Function from file: cell.dm
		public virtual void corrupt(  ) {
			this.charge /= 2;
			this.maxcharge = Num13.MaxInt( ((int)( ( this.maxcharge ??0) / 2 )), this.chargerate );

			if ( Rand13.PercentChance( 10 ) ) {
				this.rigged = true;
			}
			return;
		}

		// Function from file: cell.dm
		public void explode(  ) {
			dynamic T = null;
			int devastation_range = 0;
			int heavy_impact_range = 0;
			int light_impact_range = 0;
			int flash_range = 0;

			T = GlobalFuncs.get_turf( this.loc );

			if ( this.charge == 0 ) {
				return;
			}
			devastation_range = -1;
			heavy_impact_range = Num13.Floor( Math.Sqrt( this.charge ??0 ) / 60 );
			light_impact_range = Num13.Floor( Math.Sqrt( this.charge ??0 ) / 30 );
			flash_range = light_impact_range;

			if ( light_impact_range == 0 ) {
				this.rigged = false;
				this.corrupt();
				return;
			}
			GlobalFuncs.explosion( T, devastation_range, heavy_impact_range, light_impact_range, flash_range );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: cell.dm
		public int give( double? amount = null ) {
			int power_used = 0;

			
			if ( this.rigged && ( amount ??0) > 0 ) {
				this.explode();
				return 0;
			}

			if ( ( this.maxcharge ??0) < ( amount ??0) ) {
				amount = this.maxcharge;
			}
			power_used = Num13.MinInt( ((int)( ( this.maxcharge ??0) - ( this.charge ??0) )), ((int)( amount ??0 )) );

			if ( this.crit_fail ) {
				return 0;
			}

			if ( !Rand13.PercentChance( ((int)( this.reliability )) ) ) {
				this.minor_fault++;

				if ( Rand13.PercentChance( this.minor_fault ) ) {
					this.crit_fail = true;
					return 0;
				}
			}
			this.charge += power_used;
			return power_used;
		}

		// Function from file: cell.dm
		public virtual bool use( double? amount = null ) {
			
			if ( this.rigged && ( amount ??0) > 0 ) {
				this.explode();
				return false;
			}

			if ( ( this.charge ??0) < ( amount ??0) ) {
				return false;
			}
			this.charge = ( this.charge ??0) - ( amount ??0);

			if ( !( this.loc is Obj_Machinery_Power_Apc ) ) {
				GlobalFuncs.feedback_add_details( "cell_used", "" + this.type );
			}
			return true;
		}

		// Function from file: cell.dm
		public double percent(  ) {
			return ( this.charge ??0) * 100 / ( this.maxcharge ??0);
		}

		// Function from file: cell.dm
		public void updateicon(  ) {
			this.overlays.Cut();

			if ( ( this.charge ??0) < 0.01 ) {
				return;
			} else if ( ( this.charge ??0) / ( this.maxcharge ??0) >= 0.995 ) {
				this.overlays.Add( new Image( "icons/obj/power.dmi", "cell-o2" ) );
			} else {
				this.overlays.Add( new Image( "icons/obj/power.dmi", "cell-o1" ) );
			}
			return;
		}

		// Function from file: ninjaDrainAct.dm
		public override dynamic ninjadrain_act( Obj_Item_Clothing_Suit_Space_SpaceNinja S = null, Ent_Static H = null, Obj_Item_Clothing_Gloves_SpaceNinja G = null ) {
			dynamic _default = null;

			
			if ( !( S != null ) || !( H != null ) || !( G != null ) ) {
				return "INVALID";
			}
			_default = 0;

			if ( Lang13.Bool( this.charge ) ) {
				
				if ( G.candrain && GlobalFuncs.do_after( H, 30, null, this ) ) {
					_default = this.charge;

					if ( Convert.ToDouble( S.cell.charge + this.charge ) > ( S.cell.maxcharge ??0) ) {
						S.cell.charge = S.cell.maxcharge;
					} else {
						S.cell.charge += this.charge;
					}
					this.charge = 0;
					this.corrupt();
					this.updateicon();
				}
			}
			return _default;
		}

	}

}