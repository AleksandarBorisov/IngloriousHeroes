namespace IngloriousHeros.Core.UI.Models
{
    class HerosModels
    {
    
        //The size is determined by the bottom most right most model
        private string[,] models = new string[MainScreen.BruteModel.Row + 1, MainScreen.BruteModel.Col + 1];

        private static HerosModels instanceHolder;

        private HerosModels()
        {
            AssignValues();
        }

        public static HerosModels Instance
        {
            get
            {
                return instanceHolder = new HerosModels();
            }
        }

        private void AssignValues()
        {
            Models[MainScreen.ArcherModel.Row, MainScreen.ArcherModel.Col] = @"
                                        
                                        
                                        
     --\|    / < ___ > \
      --\|   '-._____.-'  /`.
       --\|   ,| ^_^ |,  /   :.
          \    ((())))  /    //
           \     | |   /     // 
            ,############\ //
           /  #########,  \
          /_<'#########'./_\
         '_7_ ######### _o_7
          (  \[o-o-o-o]/  )
           \|l#########l|/          
              ####_####             
             /    |    \            
~~~~~~~~~~~~~|    |    |~~~~~~~~~~~~~~~~
             |_  _|_  _|       ~~ ~ 
      ~ ~    |\\//|\\//|            
             \//\\|//\\/   ~ ~~~~
           ___\\// \\//___
          (((___X\ /X___)))
                                        
                                        
                                        
";
            Models[MainScreen.BruteModel.Row, MainScreen.BruteModel.Col] = @"
                                    
         O
      ,-.|____________________
   O==+-|(>-------- --  -     .>
      `- |""""""""""""""d88b""""""""""""""""
       | O     d8P 88b
       |  \    88= ,=88
       |   )   9b _. 88b
       `._ `.   8`--'888
        |    \--'\   `-8___
         \`-.              \
          `. \ -       _ / <
            \ `---   ___/|_-\
             |._ _. |_-|
             \  _ _  /.-\
              | -! . !- ||   |
              \ "" | ! |"" /\   |
               =oO)X(Oo=  \  /
               888888888   < \
              d888888888b  \_/ Ojo 98  
              88888888888
                                        
                                        
";
            Models[MainScreen.GnomeModel.Row, MainScreen.GnomeModel.Col] = @"
                                        
                  (\    /)
                  |_)//(_|
                  |4\_/4)(
                 '( (_  -)D
                   ) _)  /\,__
                 _,\_._,/ /   `)
    \.,_,,      ( _   ~ .   ,   \
     \   (\      \(   \/  _)(    )
      \   \\      )). _______>-. `*
       \  /\\    _'( /   /\  '\  _)
        \( ,\\.-'  '/    \/    \/
         '  \><)_'.)|/\/\/\/\/\|
              \) ,( |\/\/\/\/\/|
              ' ((  \    /\    /
               ((((  \___\/___/)
                ((,) /   ((()   )
                 ""..-,  (()(""   /
                  _//.   ((() .""
          _____ //,/"" ___ ((( ', ___    
                           ((  )
                            / /
                          _/,/'
                        /,/,""
                                        
";
            Models[MainScreen.JediModel.Row, MainScreen.JediModel.Col] = @"
                                     
                       .-.
                      |_:_|
                     /(_Y_)\
.                   ( \/M\/ )
 '.               _.'-/'-'\-'._
   ':           _/.--'[[[[]'--.\_
     ':        /_'  : |::"" | :  '.\
       ':     //   ./ |oUU| \.'  :\
         ':  _:'..' \_|___|_/ :   :|
           ':.  .'  |_[___] _|  :.':\
            [::\ |  :  | |  :   ; : \
             '-'   \/'.| |.' \  .;.' |
             |\_    \  '-'   :       |
             |  \    \ .:    :   |   |
             |   \    | '.   :    \  |
             /       \   :. .;       |
            /     |   |  :__/     :  \\
           |  |   |    \:   | \   |   ||
          /    \  : :  |:   /  |__|   /|
          |     : : :_/_|  /'._\  '--|_\
          /___.-/_|-'   \  \
                         '-'
";
            Models[MainScreen.WarriorModel.Row, MainScreen.WarriorModel.Col] = @"
                     ,dM
                   dMMP
                  dMMM'
                  \MM/
                  dMMm.
                 dMMP'_\---.
                _| _ p;88;`.
              ,db; p >  ;8P|  `.
             (``T8b,__,'dP |   |
             |   `Y8b..dP  ;_  |
             |    |`T88P_ /  `\;
             :_.-~|d8P'`Y/    /
              \_ TP;   7`\
   ,,__        >   `._  /'  /   `\_
   `._ """"""""~~~~------|`\;' ;     ,'
      """"""~~~-----~~~'\__[|;' _.-'  `\   
              ;--..._.-'-._     ;
             /      /`~~""'   ,'`\_ ,/
            ;_    /'        /    ,/
            | `~-l         ;    /
            `\    ;       /\.._|
              \    \      \     \
              /`---';      `----'
             (     /            
              `---'";
            Models[MainScreen.WizzardModel.Row, MainScreen.WizzardModel.Col] = @"
                                       
                     ____
                   .'* *.'
                __/_*_*(_
               / _______ \
              _\_)/___\(_/_
             / _((\- -/))_ \
             \ \())(-)(()/ /
              ' \(((()))/ '
             / ' \)).))/ ' \
            / _ \ - | - /_  \
           (   ( .;''';. .'  )
           _\""__ /    )\ __""/_
             \/  \   ' /  \/
              .'  '...' ' )
               / /  |  \ \
              / .   .   . \
             /   .     .   \
            /   /   |   \   \
          .'   /    b    '.  '.
      _.-'    /     Bb     '-. '-._
  _.-'       |      BBb       '-.  '-.
 (________mrf\____.dBBBb.________)____) 
";
        }
        public string[,] Models
        {
            get
            {
                return this.models;
            }
            set
            {
                this.models = value;
            }
        }

        public string this[int indexRow, int indexCol]
        {
            get
            {
                return Models[indexRow, indexCol];
            }
        }
    }
}
