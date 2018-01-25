using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IOSerialize
{
    public enum FileType
    {
        /// <summary>
        /// 未知文件
        /// </summary>
        [Display(Name = "未知文件")]
        Uunknown = 0,

        /// <summary>
        /// Jpg文件
        /// </summary>
        [Display(Name = "Jpg 文件")]
        Jpg = 255216,

        /// <summary>
        /// Png 文件
        /// </summary>
        [Display(Name = "Png 文件")]
        Png = 13780,

        /// <summary>
        /// doc xls ppt wps 文件
        /// </summary>
        [Display(Name = "doc xls ppt wps 文件")]
        Doc = 208207,


        //* 8075 docx pptx xlsx zip
        //* 5150 txt
        //* 8297 rar
        //* 7790 exe
        //* 3780 pdf
        //* 4946/104116 txt
        //* 7173        gif 
        //* 255216      jpg
        //* 6677        bmp
        //* 239187      txt,aspx,asp,sql
        //* 208207      xls.doc.ppt
        //* 6063        xml
        //* 6033        htm,html
        //* 4742        js
        //* 8075        xlsx,zip,pptx,mmap,zip
        //* 8297        rar   
        //* 01          accdb,mdb
        //* 7790        exe,dll
        //* 5666        psd 
        //* 255254      rdp 
        //* 10056       bt种子 
        //* 64101       bat 
        //* 4059        sgf    

    }
}
