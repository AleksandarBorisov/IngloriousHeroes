﻿using System;
using System.Collections.Generic;
using System.Text;
using IngloriousHeros.Contracts;

namespace IngloriousHeros.Core.UI.Models
{
    class FontSolidLetters : IFont
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
                return letters[index];
            }
        }
    }
}
