/****************************************************************************/
/*                               DISCLAIMER:                                */
/*                      This file contains sample code.                     */
/*     Such sample code described herein is provided on an "as is"          */
/*    basis, without warranty of any kind, not even implied warranties of   */
/*  non-infringement, merchantability or fitness  for a particular purpose, */
/*                 to the fullest extent permitted by law.                  */
/*                                                                          */
/*                 THIS CODE IS NOT RECOMMENDED FOR USE IN                  */
/*                   PRODUCTION SYSTEMS OR PRODUCTION USE.                  */
/*                                                                          */
/*   Kalkitech does not warrant, guarantee or make any representations      */
/* regarding the use, results of use, accuracy, timeliness or completeness  */
/* of any data or information relating to the sample code. Kalkitech        */
/* disclaims all warranties, express or implied, and in particular,         */
/* disclaims all warranties of merchantability, fitness for a particular    */
/* purpose, and warranties related to the code, or any service or software  */
/*                             related thereto.                             */
/*                                                                          */
/*  Kalkitech shall not be liable for any direct, indirect or consequential */
/*  damages or costs of any type arising out of any action taken by you or  */
/*   others related to the sample code. Such sample code provided herein is */
/*      for illustrative purposes only, has not passed through Kalkitech    */
/*   standard testing and validation and is not intended for any production */
/*  use. Such sample code is not subject to Kalkitech agreements related to */
/*                 Sales, Technical Support, or Licensing.                  */
/****************************************************************************/

using System;
using System.Runtime.InteropServices;
using DLMS_CLIENT;

namespace DLMS_SECURITY
{
    public class DLMSSecurity
    {
        [DllImport("SecurityLibrary.dll", EntryPoint = "dll_securityLibEncrypt", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte SecurityLibEncrypt(byte encMethod, IntPtr key, ushort keyLen, IntPtr plainText_p, uint ptLen,
                                           IntPtr cipherText_p, IntPtr initialisationVector, ushort ivLen, IntPtr aad,
                                           uint aadLen, IntPtr authTag, uint authTagLen, byte SecuritySuite,
                                           byte enableCompression, IntPtr compressedlength);


        [DllImport("SecurityLibrary.dll", EntryPoint = "dll_securityLibDecrypt", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte SecurityLibDecrypt(byte encMethod, IntPtr key, ushort keyLen, IntPtr plainText_p, uint ptLen,
                                           IntPtr cipherText_p, IntPtr initialisationVector, ushort ivLen, IntPtr aad,
                                           uint aadLen, IntPtr authTag, uint authTagLen, byte SecuritySuite,
                                           byte enableCompression, IntPtr compressedlength);

        [DllImport("SecurityLibrary.dll", EntryPoint = "dll_securityLibHash", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte SecurityLibHash(byte hashMethod, IntPtr plainText_p, ushort ptLen, IntPtr cipherText_p);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_signatureGeneration", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte signatureGeneration(IntPtr privateKey, IntPtr plainText, uint ptLen, byte notUsedByteIndex, IntPtr sig, IntPtr sigLen, byte DER_Encoding, byte SecuritySuite);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_signatureVerification", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern uint signatureVerification(IntPtr publicKey, IntPtr plainText_p, uint ptLen, byte notUsedByteIndex, IntPtr sig, uint slen, byte DER_Encoding, byte SecuritySuite);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_ParseCertificate_CRT", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte parseCertificate_CRT(IntPtr cert, uint certLen, IntPtr certificate_publicKey, IntPtr certificate_Signature, IntPtr signLen, IntPtr systemTitle, byte SecuritySuite);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_digitalSigKeyPairGen", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte digitalSigKeyPairGen(IntPtr privateKey, IntPtr publicKey);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_digitalSigKeyPairGen", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte generateKeypair(IntPtr privateKey, IntPtr publicKey);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_GetCertificateIdentificationByserial", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte GetCertificateIdentificationByserial(IntPtr serial_number, byte serial_numberLen, IntPtr issuer, byte issuerLen, IntPtr Certifcate, uint CertificateLen, IntPtr CRT, IntPtr len);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_getDigCertificateCRT", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte getDigCertificateCRT(IntPtr certBuf_Len_CRT, IntPtr Cert_Buf, IntPtr PrivateKey, IntPtr PublicKey, IntPtr PublicKey2, byte flag, byte SecuritySuite);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_GenerateSharedKey_SHA256", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte GenerateSharedKey_SHA256(IntPtr PrivateKeyServer, IntPtr PublicKeyClient, IntPtr result, IntPtr Algo_ID, IntPtr Server_Sys, IntPtr Client_Sys);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_GenerateSharedKey", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte GenerateSharedKey(IntPtr PrivateKeyServer, IntPtr PublicKeyClient, IntPtr result, byte SecuritySuite);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_KeyDerivationFunction", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte KeyDerivationFunction(IntPtr cntr, IntPtr sharedSecret, IntPtr algID, IntPtr SystitleClient, IntPtr SystitleServer, IntPtr DerivedKey, byte secSuite);

        [DllImport("AsymmetricSecurity.dll", EntryPoint = "dll_assymSecurityLibHash", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern byte assymHashGenerate(byte hashMethod, IntPtr plainText_p, byte ptLen, IntPtr hash);

        /*
         * Function: encrypt
         * Description:
         *  encrypts the data for HLS Authentication and data transport secuirty
         * Arguments:
         *	encMethod    - The encryption method used, 2 for AES and 5 for GCM
         *  key          - The secret key
         *  keyLen		 - The key length in bytes
         *	plainText_p  - The plaintext
         *	ptLen        - The length of the plaintext (ciphertext length is the same)
         *	cipherText_p - The ciphertext
         *  initialisationVector - The initial vector
         *	ivLen	     - The length of the initial vector
         *	aad          - The additional authentication data (header)
         *	aadLen       - The length of the aad
         *	authTag      - The authentication tag
         * Returns:
         *  unsigned char  - result 
         */
        public static DLMSClient.CryptCallback encrypt =
                                    (byte encMethod,
                                     IntPtr key,
                                     ushort keyLen,
                                     IntPtr plainText_p,
                                     uint ptLen,
                                     IntPtr cipherText_p,
                                     IntPtr initialisationVector,
                                     ushort ivLen,
                                     IntPtr aad,
                                     uint aadLen,
                                     IntPtr authTag,
                                     uint authTagLen,
                                     byte SecuritySuite,
                                    byte enableCompression,
                                    IntPtr compressedlength) =>
                                    {
                                        return SecurityLibEncrypt(encMethod, key, keyLen, plainText_p, ptLen, cipherText_p, initialisationVector, ivLen, aad, aadLen, authTag, authTagLen, SecuritySuite, enableCompression, compressedlength);

                                    };

        /*
         * Function: decrypt
         * Description:
         *  decrypts the data for HLS Authentication and data transport secuirty
         * Arguments:
         *	encMethod    - The encryption method used, 2 for AES and 5 for GCM
         *  key          - The secret key
         *  keyLen		 - The key length in bytes
         *	plainText_p  - The plaintext
         *	ptLen        - The length of the plaintext (ciphertext length is the same)
         *	cipherText_p - The ciphertext
         *  initialisationVector - The initial vector
         *	ivLen	     - The length of the initial vector
         *	aad          - The additional authentication data (header)
         *	aadLen       - The length of the aad
         *	authTag      - The authentication tag
         * Returns:
         *  unsigned char  - result 
         */
        public static DLMSClient.CryptCallback decrypt =
                                    (byte encMethod,
                                     IntPtr key,
                                     ushort keyLen,
                                     IntPtr plainText_p,
                                     uint ptLen,
                                     IntPtr cipherText_p,
                                     IntPtr initialisationVector,
                                     ushort ivLen,
                                     IntPtr aad,
                                     uint aadLen,
                                     IntPtr authTag,
                                     uint authTagLen,
                                     byte SecuritySuite,
                                    byte enableCompression,
                                    IntPtr compressedlength) =>
                                    {
                                        return SecurityLibDecrypt(encMethod, key, keyLen, plainText_p, ptLen, cipherText_p, initialisationVector, ivLen, aad, aadLen, authTag, authTagLen, SecuritySuite, enableCompression, compressedlength);

                                    };

        /*
         * Function: computeHash
         * Description:
         *  decrypts the data for HLS Authentication and data transport security
         * Arguments:
         *	hashMethod   - Hashing algorithm used, 3 for MD5 and 4 for SHA1
         *	plainText_p  - The plaintext
         *	ptLen        - The length of the plaintext (ciphertext length is the same)
         *	cipherText_p - The ciphertext
         * Returns:
         *  unsigned char  - result
         */
        public static DLMSClient.HashCallback computeHash =
                                    (byte hashMethod,
                                     IntPtr plainText_p,
                                     ushort ptLen,
                                     IntPtr cipherText_p) =>
                                    {
                                        return SecurityLibHash(hashMethod, plainText_p, ptLen, cipherText_p);

                                    };


        /*

	     *Signature Generation
	     */

        public static DLMSClient.SigGenCallback computeSigGen = (IntPtr privateKey,
                                        IntPtr plainText,
                                        uint ptLen,
                                         byte notUsedByteIndex,
                                        IntPtr sig,
                                        IntPtr sigLen,
                                        byte DER_Encoding, byte SecuritySuite) =>
        {
            return signatureGeneration(privateKey, plainText, ptLen, notUsedByteIndex, sig, sigLen, DER_Encoding, SecuritySuite);
        };

        /*
	     *Signature verification
	    */
        public static DLMSClient.SigVerCallback computeSigVer = (IntPtr publicKey,
                                        IntPtr plainText_p,
                                        uint ptLen, byte notUsedByteIndex,
                                        IntPtr sig,
                                        uint slen,
                                        byte DER_Encoding, byte SecuritySuite) =>
        {
            return signatureVerification(publicKey, plainText_p, ptLen, notUsedByteIndex, sig, slen, DER_Encoding, SecuritySuite);
        };

        public static DLMSClient.ParseCRTCallback computeParseCRT = (IntPtr cert,
                                        uint certLen,
                                        IntPtr certificate_publicKey,
                                        IntPtr certificate_Signature,
                                        IntPtr signLen,
                                        IntPtr systemTitle,
                                        byte SecuritySuite) =>
        {
            return parseCertificate_CRT(cert, certLen, certificate_publicKey, certificate_Signature, signLen, systemTitle, SecuritySuite);
        };

        /*
	     * Function: digitalSigKeyPairGen
	     * Description:
	     *  Generate digital signature key pair
	     * Arguments:
	     *  privateKey: pointer to store private key
	     *  publicKey: pointer to store public key
	     *  Returns:
	     *   unsigned char  - result
	     */

        public static DLMSClient.DigKeyPairGenCallback computeDigSigKeypairGen = (IntPtr privateKey,
                                        IntPtr publicKey) =>
        {
            return digitalSigKeyPairGen(privateKey, publicKey);
        };

        public static DLMSClient.GetCertSerialCallback computeGetCertificateIdentByserial = (IntPtr serial_number,
                                        byte serial_numberLen,
                                        IntPtr issuer,
                                        byte issuerLen,
                                        IntPtr Certifcate,
                                        uint CertificateLen,
                                        IntPtr CRT,
                                        IntPtr len) =>
        {
            return GetCertificateIdentificationByserial(serial_number, serial_numberLen, issuer, issuerLen, Certifcate, CertificateLen, CRT, len);
        };

        public static DLMSClient.GetCertCallback computeGetDigCertCRT = (IntPtr certBuf_Len_CRT,
                                        IntPtr Cert_Buf,
                                        IntPtr PrivateKey,
                                        IntPtr PublicKey,
                                        IntPtr PublicKey2,
                                        byte flag, byte SecuritySuite) =>
        {
            return getDigCertificateCRT(certBuf_Len_CRT, Cert_Buf, PrivateKey, PublicKey, PublicKey2, flag, SecuritySuite);
        };

        public static DLMSClient.GenShared256KeyCallback computeGenSharedKey_SHA256 = (IntPtr PrivateKeyServer,
                                        IntPtr PublicKeyClient,
                                        IntPtr result,
                                        IntPtr Algo_ID,
                                        IntPtr Server_Sys,
                                        IntPtr Client_Sys) =>
        {
            return GenerateSharedKey_SHA256(PrivateKeyServer, PublicKeyClient, result, Algo_ID, Server_Sys, Client_Sys);
        };

        public static DLMSClient.GenSharedKeyCallback computeGenSharedKey = (IntPtr PrivateKeyServer,
                                       IntPtr PublicKeyClient,
                                       IntPtr result,
                                       byte SecuritySuite) =>
        {
            return GenerateSharedKey(PrivateKeyServer, PublicKeyClient, result, SecuritySuite);
        };

        public static DLMSClient.KeyDerivCallback computeKeyDerivFn = (IntPtr cntr,
                                        IntPtr sharedSecret,
                                        IntPtr algID,
                                        IntPtr SystitleClient,
                                        IntPtr SystitleServer,
                                        IntPtr DerivedKey,
                                        byte secSuite) =>
        {
            return KeyDerivationFunction(cntr, sharedSecret, algID, SystitleClient, SystitleServer, DerivedKey, secSuite);
        };

        public static DLMSClient.AssymHashCallback computeAssymHashGen = (byte hashMethod,
                                        IntPtr plainText_p,
                                        byte ptLen,
                                        IntPtr hash) =>
        {
            return assymHashGenerate(hashMethod, plainText_p, ptLen, hash);
        };
    }
}
