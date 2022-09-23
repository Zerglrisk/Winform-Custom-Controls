using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal partial class Interop
{
    internal static partial class Richedit
    {
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct PARAFORMAT2
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering;
            /// <summary>
            /// PARAFORMAT 의 weffects를 재정의
            /// </summary>
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            // PARAFORMAT2 from here onwards
            /// <summary>
            /// 파라 전에 세로 간격
            /// </summary>
            public int dySpaceBefore;
            /// <summary>
            /// 메시지 후 세로 간격
            /// </summary>
            public int dySpaceAfter;
            /// <summary>
            /// 줄 간격 규칙에 따라
            /// </summary>
            public int dyLineSpacing;
            /// <summary>
            /// 스타일 핸들
            /// </summary>
            public short sStyle;
            /// <summary>
            /// 규칙 줄 간격 (tom.doc 참조)
            /// </summary>
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            /// <summary>
            /// 1/100% %음영
            /// </summary>
            public short wShadingWeight;
            /// <summary>
            /// 0을 한 입: 스타일, 1:cfpat, 2:cbpat
            /// </summary>
            public short wShadingStyle;
            /// <summary>
            /// 시작 번호 매기기에 대한 값
            /// </summary>
            public short wNumberingStart;
            /// <summary>
            /// 맞춤, 로마/아랍어, (,),)., 등등.
            /// </summary>
            public short wNumberingStyle;
            /// <summary>
            /// 1 들여쓰기 및 1 줄 텍스트를 내기 하는 공간
            /// </summary>
            public short wNumberingTab;
            //텍스트(트윕)와 테두리 사이 공간
            public short wBorderSpace;
            /// <summary>
            /// 펜 너비(트윕)를 테두리
            /// </summary>
            public short wBorderWidth;
            /// <summary>
            /// 0바이트: 있는 테두리를 지정 하는 비트
            /// 2 한입: 테두리 스타일, 3: 색 인덱스
            /// </summary>
            public short wBorders;
        }
    }
}

