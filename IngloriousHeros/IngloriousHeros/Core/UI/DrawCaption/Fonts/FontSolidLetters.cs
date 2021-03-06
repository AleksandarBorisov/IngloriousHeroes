﻿using IngloriousHeros.Core.Contracts;

namespace IngloriousHeros.Core.UI.DrawCaption.Fonts
{
    public class FontSolidLetters : IFont
    {
        private readonly string[] letters =
        {
            @"
        
 █████╗ 
██╔══██╗
███████║
██╔══██║
██║  ██║
╚═╝  ╚═╝
        ",
            @"
        
██████╗ 
██╔══██╗
██████╔╝
██╔══██╗
██████╔╝
╚═════╝ 
        ",
            @"
        
 ██████╗
██╔════╝
██║     
██║     
╚██████╗
 ╚═════╝
        ",
            @"
        
██████╗ 
██╔══██╗
██║  ██║
██║  ██║
██████╔╝
╚═════╝ 
        ",
            @"
        
███████╗
██╔════╝
█████╗  
██╔══╝  
███████╗
╚══════╝
        ",
            @"
        
███████╗
██╔════╝
█████╗  
██╔══╝  
██║     
╚═╝     
        ",
            @"
        
 ██████╗ 
██╔════╝ 
██║  ███╗
██║   ██║
╚██████╔╝
 ╚═════╝ 
        ",
            @"
        
██╗  ██╗
██║  ██║
███████║
██╔══██║
██║  ██║
╚═╝  ╚═╝
        ",
            @"
        
   ██╗
   ██║
   ██║
   ██║
   ██║
   ╚═╝
         ",
            @"
        
     ██╗
     ██║
     ██║
██   ██║
╚█████╔╝
 ╚════╝ 
        ",
            @"
        
██╗  ██╗
██║ ██╔╝
█████╔╝ 
██╔═██╗ 
██║  ██╗
╚═╝  ╚═╝
        ",
            @"
        
██╗     
██║     
██║     
██║     
███████╗
╚══════╝
        ",
            @"
           
███╗   ███╗
████╗ ████║
██╔████╔██║
██║╚██╔╝██║
██║ ╚═╝ ██║
╚═╝     ╚═╝
           ",
            @"
          
███╗   ██╗
████╗  ██║
██╔██╗ ██║
██║╚██╗██║
██║ ╚████║
╚═╝  ╚═══╝
          ",
            @"
         
 ██████╗ 
██╔═══██╗
██║   ██║
██║   ██║
╚██████╔╝
 ╚═════╝ 
         ",
            @"
        
██████╗ 
██╔══██╗
██████╔╝
██╔═══╝ 
██║     
╚═╝     
        ",
            @"
         
 ██████╗ 
██╔═══██╗
██║   ██║
██║▄▄ ██║
╚██████╔╝
 ╚══▀▀═╝ 
         ",
            @"
        
██████╗ 
██╔══██╗
██████╔╝
██╔══██╗
██║  ██║
╚═╝  ╚═╝
        ",
            @"
        
███████╗
██╔════╝
███████╗
╚════██║
███████║
╚══════╝
        ",
            @"
         
████████╗
╚══██╔══╝
   ██║   
   ██║   
   ██║   
   ╚═╝   
        ",
            @"
         
██╗   ██╗
██║   ██║
██║   ██║
██║   ██║
╚██████╔╝
 ╚═════╝ 
         ",
            @"
         
██╗   ██╗
██║   ██║
██║   ██║
╚██╗ ██╔╝
 ╚████╔╝ 
  ╚═══╝  
         ",
            @"
          
██╗    ██╗
██║    ██║
██║ █╗ ██║
██║███╗██║
╚███╔███╔╝
 ╚══╝╚══╝ 
          ",
            @"
        
██╗  ██╗
╚██╗██╔╝
 ╚███╔╝ 
 ██╔██╗ 
██╔╝ ██╗
╚═╝  ╚═╝
        ",
            @"
         
██╗   ██╗
╚██╗ ██╔╝
 ╚████╔╝ 
  ╚██╔╝  
   ██║   
   ╚═╝   
         ",
            @"
        
███████╗
╚══███╔╝
  ███╔╝ 
 ███╔╝  
███████╗
╚══════╝
        ",
            @"
        "
        };

        public FontSolidLetters()
        {

        }

        public string[] Letters
        {
            get
            {
                return this.letters;
            }

        }

        public string this[int index]
        {
            get
            {
                return Letters[index];
            }
        }
    }
}
