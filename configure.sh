#!/bin/bash

# Function to find Steam library path with Mycopunk
find_steam_library() {
  local vdf_file="$HOME/.steam/root/steamapps/libraryfolders.vdf"
  local game_name="Mycopunk"

  # Check if the VDF file exists
  if [[ ! -f "$vdf_file" ]]; then
    echo "Error: Steam library folders file not found at $vdf_file" >&2
    return 1
  fi

  # Parse the VDF file to extract library paths
  local steam_paths=()
  while IFS= read -r line; do
    # Look for lines containing "path" key
    if [[ $line =~ \"path\"[[:space:]]*\"([^\"]+)\" ]]; then
      steam_paths+=("${BASH_REMATCH[1]}")
    fi
  done <"$vdf_file"

  # Check each Steam library path for the specific game
  for steam_path in "${steam_paths[@]}"; do
    local game_path="$steam_path/steamapps/common/$game_name"
    if [[ -d "$game_path" ]]; then
      echo "$steam_path"
      return 0
    fi
  done

  echo "Error: $game_name not found in any Steam library" >&2
  return 1
}

STEAM_LIBRARY=$(find_steam_library)

if [[ -z "$STEAM_LIBRARY" ]]; then
  echo "Error: Could not find Steam library containing Mycopunk."
  echo "Please ensure Steam is installed and Mycopunk is installed."
  exit 1
fi

echo "Found Steam library containing Mycopunk at: $STEAM_LIBRARY"

# Generate Directory.Build.props content
cat >Directory.Build.props <<EOF
<Project>
    <PropertyGroup>
        <GamePath>$STEAM_LIBRARY/steamapps/common/Mycopunk</GamePath>
    </PropertyGroup>
</Project>
EOF

echo "Directory.Build.props created successfully!"
echo "GamePath set to: $STEAM_LIBRARY/steamapps/common"
