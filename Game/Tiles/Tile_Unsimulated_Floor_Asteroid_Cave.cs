// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Unsimulated_Floor_Asteroid_Cave : Tile_Unsimulated_Floor_Asteroid {

		public int? length = 100;
		public ByTable mob_spawn_list = new ByTable()
											.Set( typeof(Mob_Living_SimpleAnimal_Hostile_Asteroid_Goliath), 5 )
											.Set( typeof(Mob_Living_SimpleAnimal_Hostile_Asteroid_Goldgrub), 1 )
											.Set( typeof(Mob_Living_SimpleAnimal_Hostile_Asteroid_Basilisk), 3 )
											.Set( typeof(Mob_Living_SimpleAnimal_Hostile_Asteroid_Hivelord), 5 )
										;
		public bool sanity = true;

		// Function from file: mine_turfs.dm
		public Tile_Unsimulated_Floor_Asteroid_Cave ( dynamic loc = null, dynamic length = null, bool? go_backwards = null, int? exclude_dir = null ) : base( (object)(loc) ) {
			go_backwards = go_backwards ?? true;
			exclude_dir = exclude_dir ?? -1;

			dynamic forward_cave_dir = null;
			double? backward_cave_dir = null;

			
			if ( !Lang13.Bool( length ) ) {
				this.length = Rand13.Int( 25, 50 );
			} else {
				this.length = Lang13.IntNullable( length );
			}
			forward_cave_dir = Rand13.PickFromTable( GlobalVars.alldirs - exclude_dir );
			backward_cave_dir = GlobalFuncs.angle2dir( ( GlobalFuncs.dir2angle( forward_cave_dir ) ??0) + 180 );
			this.make_tunnel( forward_cave_dir );

			if ( go_backwards == true ) {
				this.make_tunnel( backward_cave_dir );
			}
			this.SpawnFloor( this );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: mine_turfs.dm
		public void SpawnMonster( Tile T = null ) {
			Ent_Static A = null;
			dynamic randumb = null;

			
			if ( Rand13.PercentChance( 2 ) ) {
				
				if ( this.loc is Zone_Mine_Explored ) {
					return;
				}

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( T, 7 ), typeof(Ent_Static) )) {
					A = _a;
					

					if ( A is Mob_Living_SimpleAnimal_Hostile_Asteroid ) {
						return;
					}
				}
				randumb = GlobalFuncs.pickweight( this.mob_spawn_list );
				Lang13.Call( randumb, T );
			}
			return;
		}

		// Function from file: mine_turfs.dm
		public void SpawnFloor( Tile T = null ) {
			dynamic S = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( T, 2 ) )) {
				S = _a;
				

				if ( S is Tile_Space || S.loc is Zone_Mine_Explored ) {
					this.sanity = false;
					break;
				}
			}

			if ( !this.sanity ) {
				return;
			}
			this.SpawnMonster( T );
			new Tile_Unsimulated_Floor_Asteroid( T );
			return;
		}

		// Function from file: mine_turfs.dm
		public void make_tunnel( dynamic dir = null ) {
			Tile tunnel = null;
			int next_angle = 0;
			int? i = null;
			ByTable L = null;
			dynamic edge_angle = null;
			Tile edge = null;

			tunnel = this;
			next_angle = Convert.ToInt32( Rand13.Pick(new object [] { 45, -45 }) );
			i = null;
			i = 0;

			while (( i ??0) < ( this.length ??0)) {
				
				if ( !this.sanity ) {
					break;
				}
				L = new ByTable(new object [] { 45 });

				if ( GlobalFuncs.IsOdd( GlobalFuncs.dir2angle( dir ) ) ) {
					L.Add( -45 );
				}

				foreach (dynamic _a in Lang13.Enumerate( L )) {
					edge_angle = _a;
					
					edge = Map13.GetStep( tunnel, ((int)( GlobalFuncs.angle2dir( ( GlobalFuncs.dir2angle( dir ) ??0) + Convert.ToDouble( edge_angle ) ) ??0 )) );

					if ( edge is Tile_Unsimulated_Mineral ) {
						this.SpawnFloor( edge );
					}
				}
				tunnel = Map13.GetStep( tunnel, Convert.ToInt32( dir ) );

				if ( tunnel is Tile_Unsimulated_Mineral ) {
					
					if ( ( i ??0) > 3 && Rand13.PercentChance( 20 ) ) {
						Lang13.Call( this.type, tunnel, Rand13.Int( 10, 15 ), 0, dir );
					} else {
						this.SpawnFloor( tunnel );
					}
				} else {
					break;
				}

				if ( ( i ??0) > 2 && Rand13.PercentChance( 33 ) ) {
					next_angle = -next_angle;
					dir = GlobalFuncs.angle2dir( ( GlobalFuncs.dir2angle( dir ) ??0) + next_angle );
				}
				i++;
			}
			return;
		}

	}

}