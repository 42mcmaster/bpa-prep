# SecretMessage  -  BPA Event 355 Practice Task A
# Contestant Number: ____________
#
# Encrypt words by reversing them, then shifting each letter forward 7 (wrap, keep case,
# leave digits/other characters unchanged). Decrypt reverses the process.

SHIFT = 7

def shift_char(ch, n):
    """Shift a single character by n alphabet positions.

    ch -- the character to shift
    n  -- number of positions (may be negative)
    returns the shifted character; non-letters are returned unchanged.
    """
    # TODO: handle uppercase, lowercase, and leave everything else unchanged
    pass


def encrypt(word):
    """Return the encrypted form of word (reverse, then shift each letter +SHIFT).

    word -- the plain word
    returns the encrypted string.
    """
    # TODO
    pass


def decrypt(word):
    """Return the decrypted form of word (shift each letter -SHIFT, then reverse).

    word -- the encrypted word
    returns the original string.
    """
    # TODO
    pass


def main():
    # TODO: read messages.txt, encrypt + print + write encrypted.txt,
    #       then read encrypted.txt back, decrypt, and print.
    pass


if __name__ == "__main__":
    main()
