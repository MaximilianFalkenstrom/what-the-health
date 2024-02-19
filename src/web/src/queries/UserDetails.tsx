const baseUrl = import.meta.env.VITE_BACKEND_BASE_URL;

export const fetchUserDetails = async (token: string): Promise<UserDetails> => {
  if (!token) {
    throw new Error("Could not fetch token"); // TODO: Error handling
  }

  return await fetch(`${baseUrl}/api/userdetails`, {
    headers: {
      "content-type": "application/json",
      authorization: `Bearer ${token}`,
    },
  }).then((response) => response.json() as Promise<UserDetails>);
};
