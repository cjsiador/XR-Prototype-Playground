Shader "Stencil/Invisible Mask"
{
    Properties {}
    SubShader
    {
        Tags {}

        Pass
        {
            ColorMask 0 // Make mask invisible.
            ZWrite Off // Don't write to the depth buffer.

            Stencil
            {
                Ref 1
                Comp always // always pass
                Pass Replace
            }
        }
    }
}