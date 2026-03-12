from cryptography import x509
from cryptography.hazmat.primitives import serialization
from cryptography.hazmat.primitives.serialization import pkcs12

with open("cert.pem", "rb") as f:
    cert = x509.load_pem_x509_certificate(f.read())

with open("key.pem", "rb") as f:
    key = serialization.load_pem_private_key(f.read(), password=None)

pfx = pkcs12.serialize_key_and_certificates(
    name=b"localhost",
    key=key,
    cert=cert,
    cas=None,
    encryption_algorithm=serialization.NoEncryption()
)

with open("certificate.pfx", "wb") as f:
    f.write(pfx)